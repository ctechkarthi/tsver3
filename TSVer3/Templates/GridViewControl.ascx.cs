using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;//.DataAnnotations;
using System.Globalization;
using System.Web.DynamicData;

namespace TSVer3.Templates
{
    public partial class GridViewControl : System.Web.UI.UserControl     
    {
        private GridView _gridView;

        protected void Page_Load(object sender, EventArgs e)
        {
            Control c = Parent;
            while (c != null)
            {
                if (c is GridView)
                {
                    _gridView = (GridView)c;
                    break;
                }
                c = c.Parent;
            }
        }

        protected void TextBoxPage_TextChanged(object sender, EventArgs e)
        {
            if (_gridView == null)
            {
                return;
            }
            int page;
            if (int.TryParse(TextBoxPage.Text.Trim(), out page))
            {
                if (page <= 0)
                {
                    page = 1;
                }
                if (page > _gridView.PageCount)
                {
                    page = _gridView.PageCount;
                }
                _gridView.PageIndex = page - 1;
            }
            TextBoxPage.Text = (_gridView.PageIndex + 1).ToString(CultureInfo.CurrentCulture);

        }

        protected void DropDownListPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_gridView == null)
            {
                return;
            }
            DropDownList dropdownlistpagersize = (DropDownList)sender;
            //_gridView.PageSize = Convert.ToInt32(dropdownlistpagersize.SelectedValue, CultureInfo.CurrentCulture);
            //int pageindex = _gridView.PageIndex;
            try
            {
                System.Data.DataTable getDT = Global._getDT; //(System.Data.DataTable)_gridView.DataSource;
                _gridView.PageSize = Convert.ToInt32(dropdownlistpagersize.SelectedValue, CultureInfo.CurrentCulture);
                _gridView.PageIndex = 0;
                _gridView.DataSource = getDT;
                _gridView.DataBind();

            }
            catch (Exception) { }
            finally
            {
                //if (_gridView.PageIndex != pageindex)
                //{
                //    _gridView.PageSize = Convert.ToInt32(dropdownlistpagersize.SelectedValue, CultureInfo.CurrentCulture);
                //    //if page index changed it means the previous page was not valid and was adjusted. Rebind to fill control with adjusted page
                //    _gridView.DataBind();
                //}
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (_gridView != null)
            {
                LabelNumberOfPages.Text = _gridView.PageCount.ToString(CultureInfo.CurrentCulture);
                TextBoxPage.Text = (_gridView.PageIndex + 1).ToString(CultureInfo.CurrentCulture);
                DropDownListPageSize.SelectedValue = _gridView.PageSize.ToString(CultureInfo.CurrentCulture);
                System.Data.DataTable dt = new System.Data.DataTable();
                dt = Global._getDT;
                LabelRowCount.Text = "Total No. of Records: " + Global._getDT.Rows.Count + " Records";
            }
        }

    }
}