using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ADOX;
using System.Diagnostics;

namespace conncetaccess
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //创建数据库文件
            ADOX.Catalog catalog = new Catalog();
            catalog.Create("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=d:\\test.mdb;Jet OLEDB:Engine Type=5");
            Debug.WriteLine("DataBase created");

            //建表
            ADODB.Connection cn = new ADODB.Connection();
            cn.Open("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=d:\\test.mdb", null, null, -1);
            catalog.ActiveConnection = cn;

            ADOX.Table table = new ADOX.Table();
            table.Name = "FirstTable";

            ADOX.Column column = new ADOX.Column();
            column.ParentCatalog = catalog;
            column.Name = "RecordId";
            column.Type = DataTypeEnum.adInteger;
            column.DefinedSize = 9;
            column.Properties["AutoIncrement"].Value = true;
            table.Columns.Append(column, DataTypeEnum.adInteger, 9);
            table.Keys.Append("FirstTablePrimaryKey", KeyTypeEnum.adKeyPrimary, column, null, null);
            table.Columns.Append("CustomerName", DataTypeEnum.adVarWChar, 50);
            table.Columns.Append("Age", DataTypeEnum.adInteger, 9);
            table.Columns.Append("Birthday", DataTypeEnum.adDate, 0);
            catalog.Tables.Append(table);

            cn.Close();

        }
    }
}
