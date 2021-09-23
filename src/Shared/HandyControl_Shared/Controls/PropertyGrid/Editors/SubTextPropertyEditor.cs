using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Threading;

namespace HandyControl.Controls
{
    public class SubTextPropertyEditor : PropertyEditorBase
    {
        #region 最后开发
        private CheckComboBox checkComboBox;

        //是否正在设置选中
        private bool isChange = false;
        public override FrameworkElement CreateElement(PropertyItem propertyItem)
        {
            if (propertyItem.DisplayName == "辅助按钮")
            {
                var str= propertyItem.Value.GetType().GetProperty(propertyItem.PropertyName).GetValue(propertyItem.Value);
                checkComboBox = new CheckComboBox();
                var list = new List<string>();
                list.Add("Alt");
                list.Add("Ctrl");
                list.Add("Shift");
                list.Add("Win");
                checkComboBox.ItemsSource = list;
                checkComboBox.SelectionChanged += CheckComboBox_SelectionChanged;
                checkComboBox.SelectionMode = SelectionMode.Multiple;
                Task.Run(() =>
                {
                    Init(checkComboBox, str);
                });
                return checkComboBox;
            }
            else
            {
                return new System.Windows.Controls.TextBox
                {
                    IsReadOnly = propertyItem.IsReadOnly
                };
            }
        }
        private void Init(CheckComboBox checkComboBox, object str)
        {
            Thread.Sleep(200);
            Dispatcher.BeginInvoke(new Action(() =>
            {
                checkComboBox.IsDropDownOpen = true;
                checkComboBox.IsDropDownOpen = false;
            }), DispatcherPriority.Send);
            Thread.Sleep(100);
            Dispatcher.BeginInvoke(DispatcherPriority.Loaded, new Action(() =>
            {
                if (str != null)
                {
                    foreach (var item in checkComboBox.Items)
                    {
                        isChange = true;
                        if (checkComboBox.ItemContainerGenerator.ContainerFromItem(item) is CheckComboBoxItem checkComboBoxItem)
                        {
                            if ((str as string[]).Contains((string) item))
                            {
                                checkComboBoxItem.SetCurrentValue(ListBoxItem.IsSelectedProperty, true);
                            }
                            else
                            {
                                checkComboBoxItem.SetCurrentValue(ListBoxItem.IsSelectedProperty, false);
                            }
                        }
                    }
                    isChange = false;
                }
            }));
        }

        private void CheckComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (!isChange) {
                var str = "";
                var s = sender as CheckComboBox;
                for (var i = 0; i < s.SelectedItems.Count; i++)
                {
                    str += ((string) s.SelectedItems[i]) + ",";
                }
                var subStr = str.Trim(',').Split(',');
                checkComboBox.CheckText = subStr;
            }
        }

        public override DependencyProperty GetDependencyProperty()
        {
            return CheckComboBox.CheckTextProperty;
        }
        #endregion
    }
}
