using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace HandyControl.Controls
{
    public class SubTextPropertyEditor : PropertyEditorBase
    {
        #region 最后开发
        //private CheckComboBox checkComboBox;
        //public override FrameworkElement CreateElement(PropertyItem propertyItem)
        //{
        //    if (propertyItem.DisplayName == "辅助按钮")
        //    {
        //        checkComboBox = new CheckComboBox();
        //        var list = new List<CategoryInfo>();
        //        list.Add(new CategoryInfo
        //        {
        //            Name = "Alt",
        //            Value = "Alt",
        //        });
        //        list.Add(new CategoryInfo
        //        {
        //            Name = "Ctrl",
        //            Value = "Ctrl"
        //        });
        //        list.Add(new CategoryInfo
        //        {
        //            Name = "Shift",
        //            Value = "Shift"
        //        });
        //        list.Add(new CategoryInfo
        //        {
        //            Name = "Win",
        //            Value = "Win"
        //        });
        //        checkComboBox.ItemsSource = list;
        //        checkComboBox.DisplayMemberPath = "Name";
        //        checkComboBox.SelectedValuePath = "Value";
        //        checkComboBox.SelectionChanged += CheckComboBox_SelectionChanged;
        //        return checkComboBox;
        //    }
        //    else
        //    {
        //        return new System.Windows.Controls.TextBox
        //        {
        //            IsReadOnly = propertyItem.IsReadOnly
        //        };
        //    }
        //}

        //private void CheckComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        //{
        //    var str = "";
        //    var s = sender as CheckComboBox;
        //    for (var i = 0; i < s.SelectedItems.Count; i++)
        //    {
        //        str += ((CategoryInfo) s.SelectedItems[i]).Value + ",";
        //    }
        //    var subStr = str.Trim(',').Split(',');
        //    checkComboBox.CheckText = subStr;
        //}

        //public override DependencyProperty GetDependencyProperty()
        //{
        //    return CheckComboBox.CheckTextProperty;
        //} 
        #endregion


        public override FrameworkElement CreateElement(PropertyItem propertyItem)
        {
            return new System.Windows.Controls.TextBox
            {
                IsReadOnly = propertyItem.IsReadOnly
            };
        }

        public override DependencyProperty GetDependencyProperty()
        {
            return System.Windows.Controls.TextBox.TextProperty;
        }
    }
}
