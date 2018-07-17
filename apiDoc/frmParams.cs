using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using apiDoc.Model;
using System.Text.RegularExpressions;

namespace apiDoc
{
    public partial class frmParams : Form
    {
        public List<xmlModel> lstModel;
        //public string resultValue = "";

        public frmParams(List<xmlModel> lstModel)
        {
            this.lstModel = lstModel;
            InitializeComponent();
        }

       

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            try
            {
                var sourceCode = this.txtCsCode.Text; ;
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
                        var tmpArr = Regex.Split(sourceCode, " "+item.Name, RegexOptions.IgnoreCase);  
                       

                        if (tmpArr.Count() < 2)  //分割后数组只有一个值说明没有匹配到方法名，跳出 继续下个循环;重载的方法和sqlID同名的情况 默认取第一个
                        {
                            errMsg += rowNum + "行:" + item.Name + "  没有在当前class找到方法名。"+"\r\n";
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
                            if (tmp1[1].Replace("\r\n", "").Replace(" ", "").IndexOf("{") != 0)  //为了判断后面跟的是不是{
                            {
                                //过滤  getAll();  Test(getAll());类似情况
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

                            if (lstParamS[0].Trim().IndexOf(" ") < 0 && lstParamS[0].Trim() != "") //第一个参数没有带类型或者等于空(没有参数) 说明不是声明方法
                            {
                                continue;
                            }
                            else //第一个参数带类型 说明是声明方法
                            {
                                #region 获取返回参数
                                var arrReturn = tmpArr[i - 1].Trim().Split(' ');
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
                        errMsg += rowNum+"行:"+ item.Name + "  没有匹配到方法的class名!" +"\r\n";
                    }
                }
                var frmMsg = new frmMsg(msg + "--------------\r\n" + errMsg + "\r\n是否继续?");
                frmMsg.ShowDialog();
               
                if (frmMsg.Result== 0)
                {
                    this.txtCsCode.Text = "";
                }else
                {
                    this.Close();
                    
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
          
        }

        private void txtCsCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\x1')
            {
                ((TextBox)sender).SelectAll();
                e.Handled = true;
            }
        }
    }
}
