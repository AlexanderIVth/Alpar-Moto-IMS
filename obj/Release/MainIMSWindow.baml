   M S B A M L   `   `   `  ���� H  DAlparMoto IMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:AlparMoto_IMSAlparMoto_IMS  !    AlparMoto_IMS.MainIMSWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -localclr-namespace:AlparMoto_IMS     -     � Title$  MainIMSWindow�� � Icon$ /Alpar-MotoTech-icon.ico��$
��1280��$	��720��$
��1280��$	��720�� � WindowStartupLocation$ CenterScreen=�.���  � ColumnDefinitions �� $
��861* ��� $
��419* �.+��� -    ��Name$ AddItemButton��$��0��$	��Add��$
��Left=�$��	10,10,0,0q�$	��Top=�$��30��$��90���� -   $ EditItemButton��$��0��$
��Edit��$
��Left=�$��
105,10,0,0q�$	��Top=�$��30��$��90���� -   $ RemoveItemButton��$��0��$��Remove��$
��Left=�$��
200,10,0,0q�$	��Top=�$��30��$��90���� -   $ ButtonLogout��$��Logout��$��Right=�$��	0,10,10,0q�$	��Top=�$��30��$��90��$��1���� -    ��Name$ UserTxtBlock�� �� TextAlignment$ Center=�$��Right=�$��	0,7,105,0q�$
��Wrap=�$��TextBox��$	��Top=�$	��150��$��30��$��1���� -   $ ButtonEnglish��$��English��$��Right=�$��
0,10,259,0q�$	��Top=�$��1��$��20��$��42���� -   $ ButtonTagalog��$��Tagalog��$��Right=�$��
0,10,306,0q�$	��Top=�$��1��$��20��$��45���� -	   $ ButtonIlocano��$��Ilocano��$��Right=�$��
0,10,356,0q�$	��Top=�$��1��$��20��$��43��&   System.Windows.Controls.DataGrid  -
     Name$ DataInventory��$��10,45,10,10q�$ �� IsSynchronizedWithCurrentItem$
 TrueY�	   
IsReadOnly	 . 
   SelectionMode$
 Single=�  -   $ DataUserChanges��$��10,45,10,10q�$��1��	 . $
 Single=��� -    ��Name$ SelectSearch�� �� SelectedIndex$ 0��$
��Left=�$��
442,14,0,0q�$	��Top=�$	��120��$��0��.@��� $��Part Number���� $��Product Name���� $��Description���� $��Keywords���� -    ��Name$ TxtBoxSearch��$��
567,14,0,0q� �� TextWrapping$
 Wrap=�$	��Top=��� -   $ 	TxtSearch��$
��Left=�$��
399,14,0,0q�$
��Wrap=�$��Search:��$	��Top=�$��0��