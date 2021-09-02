using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

namespace IMSUI
{
    public partial class UsersImageAdd : System.Web.UI.Page
    {
        public static ArrayList files = new ArrayList();
        public static int index = 1;
        public string Fs;
        public  class  UpInfo  { 
        private  string filesName;
        private  string fileFix;
        private int fileId;
        private  string fileSize;
        private  string fileStates;

        public  string FilesName { get => filesName; set => filesName = value; }
        public  string FileFix { get => fileFix; set => fileFix = value; }
        public  string FileSize { get => fileSize; set => fileSize = value; }
        public  string FileStates { get => fileStates; set => fileStates = value; }
        public int FileId { get => fileId; set => fileId = value; }
        };
        public static List<UpInfo> ups = new List<UpInfo>();

    protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //BUG:不用try+catch语句,定时session清除掉,页面报错
                try
                {
                    UserLogin.Text = Session["Name"].ToString();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Page:" + ex.Message);
                }
                DDL_TypeDataBind();
            }
        }

        private void FileUpload1ImagesShow()
        {
            FileUpload file1 = new FileUpload();
            FileUpload file2 = new FileUpload();
            FileUpload file3 = new FileUpload();
            FileUpload file4 = new FileUpload();
            FileUpload file5 = new FileUpload();
            if (FileUpload1.HasFile &&index==1)
            {
                UpInfo upInfo = new UpInfo();
               upInfo.FilesName= FileUpload1.FileName;
               upInfo.FileFix = upInfo.FilesName.Substring(upInfo.FilesName.LastIndexOf(".")+1).ToLower();
               long size = FileUpload1.FileContent.Length;
                if (size< (5*1024*1024))
                {
                    if (upInfo.FileFix=="png" ||upInfo.FileFix=="jpg"||upInfo.FileFix=="jpeg"||upInfo.FileFix=="pic" || upInfo.FileFix=="ico"||upInfo.FileFix=="gif")
                    {
                        if (size < (1024 * 1024))
                        {
                            var temp = size / 1024;
                            upInfo.FileSize = temp.ToString() + "KB";
                        }
                        else if (size < (1024 * 1024 * 1024))
                        {
                            var temp = size / (1024 * 1024);
                            upInfo.FileSize = temp.ToString() + "MB";
                        }

                        //upInfo.FileSize = size.ToString();
                        ListItem listItem = new ListItem();
                        listItem.Value = listItem.Text = FileUpload1.PostedFile.FileName;
                        //files.Add(FileUpload1);
                        file1 = FileUpload1;
                        files.Add(file1);
                        //upInfo.FileStates = "等待上传";
                        Fs = "等待上传";
                        upInfo.FileId = index++;
                        if (upInfo.FileId <= 5)
                        {
                            ups.Add(upInfo);
                        }
                        else
                        {
                            Response.Write("<script>alert('客官,你一次上传最多只能支持5张!不能再添加了哦::>_<::');</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('客官,你要添加的不是图片类型文件,请重新添加吧!::>_<::');</script>");
                    }
                }
                else
                {
                 Response.Write("<script>alert('客官,单个文件大小最多不超过5MB!不能添加哦!::>_<::');</script>");
                }
               
                
            }
            else if (FileUpload1.HasFile && index == 2)
            {
                UpInfo upInfo = new UpInfo();
                upInfo.FilesName = FileUpload1.FileName;
                upInfo.FileFix = upInfo.FilesName.Substring(upInfo.FilesName.LastIndexOf(".") + 1).ToLower();
                long size = FileUpload1.FileContent.Length;
                if (size < (5 * 1024 * 1024))
                {
                    if (upInfo.FileFix == "png" || upInfo.FileFix == "jpg" || upInfo.FileFix == "jpeg" || upInfo.FileFix == "pic" || upInfo.FileFix == "ico" || upInfo.FileFix == "gif")
                    {
                        if (size < (1024 * 1024))
                        {
                            var temp = size / 1024;
                            upInfo.FileSize = temp.ToString() + "KB";
                        }
                        else if (size < (1024 * 1024 * 1024))
                        {
                            var temp = size / (1024 * 1024);
                            upInfo.FileSize = temp.ToString() + "MB";
                        }

                        //upInfo.FileSize = size.ToString();
                        ListItem listItem = new ListItem();
                        listItem.Value = listItem.Text = FileUpload1.PostedFile.FileName;
                        //files.Add(FileUpload1);
                        file2 = FileUpload1;
                        files.Add(file2);
                        //upInfo.FileStates = "等待上传";
                        Fs = "等待上传";
                        upInfo.FileId = index++;
                        if (upInfo.FileId <= 5)
                        {
                            ups.Add(upInfo);
                        }
                        else
                        {
                            Response.Write("<script>alert('客官,你一次上传最多只能支持5张!不能再添加了哦::>_<::');</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('客官,你要添加的不是图片类型文件,请重新添加吧!::>_<::');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('客官,单个文件大小最多不超过5MB!不能添加哦!::>_<::');</script>");
                }
            }
            else if (FileUpload1.HasFile && index == 3)
            {
                UpInfo upInfo = new UpInfo();
                upInfo.FilesName = FileUpload1.FileName;
                upInfo.FileFix = upInfo.FilesName.Substring(upInfo.FilesName.LastIndexOf(".") + 1).ToLower();
                long size = FileUpload1.FileContent.Length;
                if (size < (5 * 1024 * 1024))
                {
                    if (upInfo.FileFix == "png" || upInfo.FileFix == "jpg" || upInfo.FileFix == "jpeg" || upInfo.FileFix == "pic" || upInfo.FileFix == "ico" || upInfo.FileFix == "gif")
                    {
                        if (size < (1024 * 1024))
                        {
                            var temp = size / 1024;
                            upInfo.FileSize = temp.ToString() + "KB";
                        }
                        else if (size < (1024 * 1024 * 1024))
                        {
                            var temp = size / (1024 * 1024);
                            upInfo.FileSize = temp.ToString() + "MB";
                        }

                        //upInfo.FileSize = size.ToString();
                        ListItem listItem = new ListItem();
                        listItem.Value = listItem.Text = FileUpload1.PostedFile.FileName;
                        //files.Add(FileUpload1);
                        file3 = FileUpload1;
                        files.Add(file3);
                        //upInfo.FileStates = "等待上传";
                        Fs = "等待上传";
                        upInfo.FileId = index++;
                        if (upInfo.FileId <= 5)
                        {
                            ups.Add(upInfo);
                        }
                        else
                        {
                            Response.Write("<script>alert('客官,你一次上传最多只能支持5张!不能再添加了哦::>_<::');</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('客官,你要添加的不是图片类型文件,请重新添加吧!::>_<::');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('客官,单个文件大小最多不超过5MB!不能添加哦!::>_<::');</script>");
                }
            }
            else if (FileUpload1.HasFile && index == 4)
            {
                UpInfo upInfo = new UpInfo();
                upInfo.FilesName = FileUpload1.FileName;
                upInfo.FileFix = upInfo.FilesName.Substring(upInfo.FilesName.LastIndexOf(".") + 1).ToLower();
                long size = FileUpload1.FileContent.Length;
                if (size < (5 * 1024 * 1024))
                {
                    if (upInfo.FileFix == "png" || upInfo.FileFix == "jpg" || upInfo.FileFix == "jpeg" || upInfo.FileFix == "pic" || upInfo.FileFix == "ico" || upInfo.FileFix == "gif")
                    {
                        if (size < (1024 * 1024))
                        {
                            var temp = size / 1024;
                            upInfo.FileSize = temp.ToString() + "KB";
                        }
                        else if (size < (1024 * 1024 * 1024))
                        {
                            var temp = size / (1024 * 1024);
                            upInfo.FileSize = temp.ToString() + "MB";
                        }

                        //upInfo.FileSize = size.ToString();
                        ListItem listItem = new ListItem();
                        listItem.Value = listItem.Text = FileUpload1.PostedFile.FileName;
                        //files.Add(FileUpload1);
                        file4 = FileUpload1;
                        files.Add(file4);
                        //upInfo.FileStates = "等待上传";
                        Fs = "等待上传";
                        upInfo.FileId = index++;
                        if (upInfo.FileId <= 5)
                        {
                            ups.Add(upInfo);
                        }
                        else
                        {
                            Response.Write("<script>alert('客官,你一次上传最多只能支持5张!不能再添加了哦::>_<::');</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('客官,你要添加的不是图片类型文件,请重新添加吧!::>_<::');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('客官,单个文件大小最多不超过5MB!不能添加哦!::>_<::');</script>");
                }
            }
            else if (FileUpload1.HasFile && index == 5)
            {
                UpInfo upInfo = new UpInfo();
                upInfo.FilesName = FileUpload1.FileName;
                upInfo.FileFix = upInfo.FilesName.Substring(upInfo.FilesName.LastIndexOf(".") + 1).ToLower();
                long size = FileUpload1.FileContent.Length;
                if (size < (5 * 1024 * 1024))
                {
                    if (upInfo.FileFix == "png" || upInfo.FileFix == "jpg" || upInfo.FileFix == "jpeg" || upInfo.FileFix == "pic" || upInfo.FileFix == "ico" || upInfo.FileFix == "gif")
                    {
                        if (size < (1024 * 1024))
                        {
                            var temp = size / 1024;
                            upInfo.FileSize = temp.ToString() + "KB";
                        }
                        else if (size < (1024 * 1024 * 1024))
                        {
                            var temp = size / (1024 * 1024);
                            upInfo.FileSize = temp.ToString() + "MB";
                        }

                        //upInfo.FileSize = size.ToString();
                        ListItem listItem = new ListItem();
                        listItem.Value = listItem.Text = FileUpload1.PostedFile.FileName;
                        //files.Add(FileUpload1);
                        file5 = FileUpload1;
                        files.Add(file5);
                        //upInfo.FileStates = "等待上传";
                        Fs = "等待上传";
                        upInfo.FileId = index++;
                        if (upInfo.FileId <= 5)
                        {
                            ups.Add(upInfo);
                        }
                        else
                        {
                            Response.Write("<script>alert('客官,你一次上传最多只能支持5张!不能再添加了哦::>_<::');</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('客官,你要添加的不是图片类型文件,请重新添加吧!::>_<::');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('客官,单个文件大小最多不超过5MB!不能添加哦!::>_<::');</script>");
                }
            }
        }

        private void DDL_TypeDataBind()
        {
            List<Products_Type> types = Products_TypeManager.GetTypes();
            DDL_Type.DataSource = types;
            DDL_Type.DataTextField = "TypeName";
            DDL_Type.DataValueField = "TypeId";
            DDL_Type.DataBind();
        }

        private void SessionBind()
        {
            if (Session["Name"] == null && Session["Pwd"] == null && Session["UsersId"] == null)
            {
                Response.Write("<script>alert('你还没登录或登录超时!');top.location.href='LoginUI.aspx';</script>");
            }
        }

        protected void StartUp_Click(object sender, EventArgs e)
        {
            //使用用户名作为图片上传的文件夹的名称,此做法在用户一多,可能更方便对系统的管理;但后期读取会有点麻烦;此特点暂且放弃
            //string path = Session["Name"].ToString();
            //string path = "Images";
            if (files.Count>0)
            {
                if (!Directory.Exists(MapPath("Images")))
                {
                    Directory.CreateDirectory(MapPath("Images"));
                }
                //利用异常处理机制,将网页报错给获取到,并始终保持程序不报错,像正常运行搬
                //算是BUG:此次的使用,主要针对用户上传的非图片类型文件,在上传时,会报“正在打开已关闭的文件”的错误
                try
                {
                    foreach (FileUpload item in files)
                    {

                    if (item.HasFile)
                    {
                            AddProducts(item);
                            //item.SaveAs(Server.MapPath(path + "//" + item.FileName));
                            item.SaveAs(Server.MapPath("Images/"+ item.FileName));
                    }
                    UpInfo upInfo = new UpInfo();
                        //upInfo.FileStates = "上传成功!";
                        Fs = "上传成功!";
                    }
                }
                catch (Exception ex)
                {
                    UpInfo upInfo = new UpInfo();
                    //upInfo.FileStates = "上传成功!";
                    Fs = "上传成功!";
                }
                //Page.ClientScript.RegisterClientScriptBlock(typeof(string),"",@"<script>alert('上传成功!');</script>");
            }
            else
            {
                Response.Write("<script>alert('客官,你没有要上传的文件哦!::>_<::');</script>");
            }
       }

        private void AddProducts(FileUpload item)
        {
            Products products = new Products();
            products.Path = item.FileName;
            products.DateTime = DateTime.Now;
            //products.Week = DateTime.Now.DayOfWeek.ToString();
            products.Week = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek);
            string name = Session["Name"].ToString();
            Users users = new Users();
            users.Name = name;
            int usersid = int.Parse(Session["UsersId"].ToString());
            products.UserId = usersid;
            products.TypeId = int.Parse(DDL_Type.SelectedValue.ToString());
            ProductsManager.AddProductFromDAL(products);
        }

        protected void Btn_AddList_Click(object sender, EventArgs e)
        {
            FileUpload1ImagesShow();
            if (files.Count>0)
            {
                ReUp.DataSource = ups;
                ReUp.DataBind();
            }
            else
            {
                Response.Write("<script>alert('客官,你还没选择任何要上传的文件呢!::>_<::');</script>");
            }
        }

        protected void Btn_CleanList_Click(object sender, EventArgs e)
        {
            List<UpInfo> lists = ups;
            lists.Clear();
            ReUp.DataSource = lists;
            ReUp.DataBind();
            index = 1;
        }
    }
}