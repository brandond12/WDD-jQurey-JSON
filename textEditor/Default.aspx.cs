/*
* FILE : Default.aspx.cs
* PROJECT : PROG 2000 - Text Editor with AJAX
* PROGRAMMER : Brandon Davies
* FIRST VERSION : 2015-12/02
* DESCRIPTION : This program is a basic text editor that allows the user to open a file, edit contents and save to a file
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.Script.Services;
using System.Web.Script.Serialization;

namespace textEditor
{
    public partial class _Default : System.Web.UI.Page
    {

        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public string testPage()
        {
            return "Yay";
        }


        [WebMethod]
        //[ScriptMethod(UseHttpGet = true)]
        public string Page_Load()
        {
            //generate list boxs files
            try
            {
                DirectoryInfo fileInfo = new DirectoryInfo(@"\MyFiles");
                FileInfo[] filesFromFolder = fileInfo.GetFiles("*.txt");

                //send to json string


                JavaScriptSerializer serializer = new JavaScriptSerializer();

                return serializer.Serialize(filesFromFolder).ToString();
                /*
                //loop through all found files
                foreach (FileInfo file in files)
                {
                    bool there = false;
                    //loop through all items in list box
                    foreach(ListItem item in lstbx_fileSelection.Items)
                    {
                        if(item.Text == file.Name)
                        {
                            there = true;//if the found file and item in list box match, this file is already added
                        }
                    }
                    //if file wasnt there, add it
                    if (!there)
                    {
                        lstbx_fileSelection.Items.Add(file.Name);
                    }
                 
                }*/
            
            }
            catch(Exception)
            {
                //opening directory failed
                //show error message and disable features that wont work
                System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE=JavaScript>alert(\"\\MyFiles not found\")</SCRIPT>");
                btn_Open.Enabled = false;
                btn_Save.Enabled = false;
            }
            return "";
        }

        protected void btn_Open_Click(object sender, EventArgs e)
        {
            //check list box selection
            //if there is a selection
            if (lstbx_fileSelection.SelectedIndex != -1)
            {
                //assign txt_SaveAs to selection
                txtbx_SaveAs.Text = lstbx_fileSelection.SelectedItem.Text;

                //read all data from file to text box
                txtbx_editingArea.Text = File.ReadAllText(@"\MyFiles\" + lstbx_fileSelection.SelectedItem.Text);
                //end if
            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            //check txtbx isnt empty
            if (txtbx_SaveAs.Text != "")
            {
                //save all txtbx data in file
                File.WriteAllText(@"\MyFiles\" + txtbx_SaveAs.Text, txtbx_editingArea.Text);
            }
        }
    }
}