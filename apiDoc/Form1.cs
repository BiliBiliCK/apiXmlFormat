using apiDoc.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace apiDoc
{
    public partial class Form1 : Form
    {

        List<xmlModel> lstModel = new List<xmlModel>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            try
            {
                lstModel.Clear();
                this.txtResult.Text = "";

                var txtXml = textBox1.Text.Trim();
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(txtXml);
                XmlNodeList ss = doc.LastChild.LastChild.ChildNodes;
                foreach (XmlNode item in ss)
                {
                    if (item.HasChildNodes == false)
                        continue;
                    if (item.Attributes[0].Value.Contains("T:"))
                        continue;
                    //单个函数
                    xmlModel xmlEntity = new xmlModel();
                    xmlEntity.Name = item.Attributes[0].Value.Split('(')[0].Split('.').Last();
                    xmlEntity.Type = item.Attributes[0].Value.Split('(')[0].Split('.')[item.Attributes[0].Value.Split('(')[0].Split('.').Length - 2];
                    var lstParam = new List<string>();
                    foreach (XmlNode y in item.ChildNodes)
                    {

                        if (y.Name == "summary")
                        {

                            xmlEntity.Desc = y.InnerText.Replace("\r\n            ", "");
                        }

                        if (y.Name == "param")
                        {
                            lstParam.Add(y.Attributes[0].Value);
                        }
                    }
                    xmlEntity.Params = string.Join(",", lstParam);
                    lstModel.Add(xmlEntity);

                }
                createTxt(lstModel);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void createTxt(List<xmlModel> lstModel)
        {
            StringBuilder str = new StringBuilder();
            foreach (var item in lstModel)
            {
                str.AppendLine(item.Name + "\t" + item.Desc + "\t" + item.Params + "\t" + item.ReturnType + "\t" + item.Type);
            }
            txtResult.Text = str.ToString(); ;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(txtResult.Text);
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
        }

       
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\x1')
            {
                ((TextBox)sender).SelectAll();
                e.Handled = true;
            }
        }

        private void txtResult_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\x1')
            {
                ((TextBox)sender).SelectAll();
                e.Handled = true;
            }
        }

        private void btn_Param_Click(object sender, EventArgs e)
        {
            var frmParam = new frmParams(lstModel);
            frmParam.ShowDialog();
            createTxt(lstModel);
        }


        string defaultfilePath = "";
        /// <summary>
        /// 选择文件夹，分析cs文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ReadFiles_Click(object sender, EventArgs e)
        {
            var result = false; //是否匹配到文件
            //ThreadStart childref = new ThreadStart(CallToChildThread);

            //Thread childThread = new Thread(childref);
            //childThread.Start();
          
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (defaultfilePath != "")
            {
                //设置此次默认目录为上一次选中目录  
                dialog.SelectedPath = defaultfilePath;
            }else
            {
                dialog.SelectedPath = @"G:\校园本地网\trunk\Execute\Apps\xml";
            }

           
            //dialog.RootFolder = Environment.SpecialFolder.MyComputer;
            dialog.Description = "请选择文件路径";

            var resultStr = new StringBuilder();
            if (dialog.ShowDialog() == DialogResult.OK)
            {

                //记录选中的目录  
                defaultfilePath = dialog.SelectedPath;

                DirectoryInfo TheFolder = new DirectoryInfo(dialog.SelectedPath);

                //遍历文件
                foreach (FileInfo NextFile in TheFolder.GetFiles())
                {
                    this.btn_ReadFiles.Invoke(new Action(delegate ()
                    {
                        this.btn_ReadFiles.Text = "正在匹配...";
                    }));
                   
                    if (NextFile.Extension.ToUpper() == ".CS")
                    {
                        //【1】创建文件流
                        FileStream fs = new FileStream(NextFile.FullName, FileMode.Open);
                        //【2】创建读取器
                        StreamReader sr = new StreamReader(fs, Encoding.Default);
                        //【3】以流的方式读取数据
                        var sourceCode = sr.ReadToEnd();
                        //【4】关闭读取器
                        sr.Close();
                        //【5】关闭文件流
                        fs.Close();


                        resultStr.AppendLine(BatchChange(sourceCode,NextFile.Extension));
                        createTxt(lstModel);
                        this.btn_ReadFiles.Text = "文件" + NextFile.Name + "匹配完成！";
                        result = true;
                    }
                }

                this.btn_ReadFiles.Text = "指定文件夹分析cs文件";
                if (result)
                {
                    var frmMsg = new frmMsg(resultStr.ToString());
                    frmMsg.ShowDialog();
                   
                }
                else
                {
                    MessageBox.Show("匹配完成,未匹配到文件！");

                }

            }
        }


        private string BatchChange(string csCode,string fileName)
        {
            try
            {
                var sourceCode = csCode; ;
                var msg = "";
                var errMsg = "";
                var rowNum = 0;
                foreach (var item in lstModel)  //遍历方法集合
                {
                    rowNum += 1;
                    if (sourceCode.ToUpper().IndexOf(item.Type.ToUpper()) >= 0) //判断当前参数文本是否是当前方法的所在的class
                    {

                        msg += rowNum + "行:" + item.Name;

                        //按方法名截取  方法名前+空格是因为防止sql的ID与方法重名
                        var tmpArr = Regex.Split(sourceCode, " " + item.Name, RegexOptions.IgnoreCase);


                        if (tmpArr.Count() < 2)  //分割后数组只有一个值说明没有匹配到方法名，跳出 继续下个循环;重载的方法和sqlID同名的情况 默认取第一个
                        {
                            errMsg += rowNum + "行:" + item.Name + "  没有在当前class找到方法名。" + "\r\n";
                            continue;
                        }

                    


                        #region 获取方法参数
                        for (int i = 1; i < tmpArr.Count(); i++)  // 第一个参数包含返回类型，后面参数包含方法的参数(如果多个，多名是构造函数)
                        {
                            var tmp1 = tmpArr[i].Split(')');
                            if (tmp1.Count() <= 1)  //没有识别到参数；跳出进行下个循环
                            {
                                continue;
                            }
                            if (tmp1[1].Remove(tmp1[1].IndexOf("//")<0?0:tmp1[1].IndexOf("//"), tmp1[1].IndexOf("\r\n")<0? 0:tmp1[1].IndexOf("\r\n") + 4).Replace("\r\n","").Replace(" ","").IndexOf("{")!=0)  //为了判断后面跟的是不是{
                            {
                                //过滤  参数 换行后有注释的问题和  getAll();  Test(getAll());类似情况
                                continue;
                            }
                            if (tmp1[0].Replace("\r\n", "").Replace(" ", "").IndexOf("(") != 0)  //为了判断前面跟的是不是（
                            {
                                //过滤  getAll()== getAllSite();类似情况
                                continue;
                            }
                            var tmp2 = tmp1[0].Split('(');  //方法的参数的字符串
                            if (tmp2.Count() <= 1)  //识别到的参数不正确；跳出进行下个循环
                            {
                                continue;
                            }
                            var lstParamS = tmp2[1].Trim(' ').Split(',');  //参数的集合

                            if(lstParamS[0].Trim().IndexOf(" ") < 0 && lstParamS[0].Trim()!="") //第一个参数没有带类型或者等于空(没有参数) 说明不是声明方法
                            {
                                continue;
                            }
                            else //第一个参数带类型 说明是声明方法
                            {
                                #region 获取返回参数
                                var arrReturn = tmpArr[i-1].Trim().Split(' ');
                                var returnType = arrReturn[arrReturn.Length - 1];  //方法返回类型
                                if (returnType.ToUpper() == "VOID")  //判断是否有返回值
                                {
                                    item.ReturnType = "无返回值";
                                }
                                else
                                {
                                    item.ReturnType = returnType;

                                }
                                msg += "  ①返回类型匹配完成。";
                                #endregion
                            }

                            if (string.Join("", tmp2).Trim() == "") //无参数的方法
                            {
                                item.Params = "空参";
                            }
                            else
                            {
                                var lstParamT = new List<string>();  //参数类型的集合   *****预留的 扩展用
                                var lstParamN = new List<string>();  //参数名的集合

                                foreach (var itemParamS in lstParamS)  //遍历处理参数
                                {
                                    var currentParam = itemParamS.Trim(' ').Split(' ');
                                    lstParamT.Add(currentParam[0]);
                                    lstParamN.Add(currentParam[currentParam.Length - 1]);
                                }
                                item.Params = string.Join(",", lstParamN);
                             
                            }

                            msg += "  ②参数匹配完成。";

                        }
                       
                        #endregion

                        msg += "\r\n";

                    }
                    else
                    {
                        errMsg += rowNum + "行:" + item.Name + "  没有匹配到方法的class名!" + "\r\n";
                    }
                }


                return msg;
               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return fileName+" 失败!";
            }
        }
    }
}
