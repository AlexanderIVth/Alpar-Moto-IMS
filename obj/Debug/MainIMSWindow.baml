   M S B A M L   `   `   `  ����H  DAlparMoto IMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:AlparMoto_IMSAlparMoto_IMS  5   	   !    AlparMoto_IMS.MainIMSWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:AlparMoto_IMS     5   	   -   5          � Title$  MainIMSWindow��5   	    � Icon$ /Alpar-MotoTech-icon.ico��6   $
��1280��6?   $	��720��6L   $
��1280��6Y   $	��720��6i    � WindowStartupLocation$ CenterScreen=�6y   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��861* �6   �� 5      $
��419* �6   .+�5   
   �� -   5         ��Name$ AddItemButton��5      $��0��6(   $	��Add��68   $
��Left=�6F   $��	10,10,0,0q�6a   $	��Top=�6t   $��30��6�   $��90��6�   6�   �� 5   
   -   5        $ EditItemButton��5      $��0��6)   $
��Edit��69   $
��Left=�6H   $��
105,10,0,0q�6c   $	��Top=�6w   $��30��6�   $��90��6�   6�   �� 5   
   -   5        $ RemoveItemButton��5      $��0��6+   $��Remove��6;   $
��Left=�6L   $��
200,10,0,0q�6g   $	��Top=�6{   $��30��6�   $��90��6�   6�   �� 5   
   -   5        $ ButtonLogout��5      $��Logout��6'   $��Right=�68   $��	0,10,10,0q�6T   $	��Top=�6g   $��30��6   $��90��6�   $��1��6�   �� 5   
   -   5         ��Name$ UserTxtBlock��5       �� TextAlignment$ Center=�6*   $��Right=�6A   $��	0,7,105,0q�6]   $
��Wrap=�6p   $��TextBox��6�   $	��Top=�6�   $	��150��6�   $��30��6�   $��1��6�   �� 5   
   -   5        $ ButtonEnglish��5      $��English��6(   $��Right=�6:   $��
0,10,259,0q�6V   $	��Top=�6j   $��1��6�   $��20��6�   $��42��6�   �� 5   
   -   5        $ ButtonTagalog��5      $��Tagalog��6(   $��Right=�6:   $��
0,10,306,0q�6V   $	��Top=�6j   $��1��6�   $��20��6�   $��45��6�   �� 5   
   -	   5        $ ButtonIlocano��5      $��Ilocano��6(   $��Right=�6:   $��
0,10,356,0q�6V   $	��Top=�6j   $��1��6�   $��20��6�   $��43��6�   &   System.Windows.Controls.DataGrid  5   
   -
   5          Name$ DataInventory��5      $��10,45,10,10q�6V   $ �� IsSynchronizedWithCurrentItem$
 TrueY�6k   	   
IsReadOnly	 . 
   SelectionMode$
 Single=�6�     5   
   -   5        $ DataUserChanges��5      $��10,45,10,10q�6W   $��1��6l   	 . $
 Single=�6�   �� 5   
   -   5         ��Name$ SelectSearch��5       �� SelectedIndex$ 0��6)   $
��Left=�6;   $��
442,14,0,0q�6V   $	��Top=�6j   $	��120��6�   $��0��6�   .@�5      �� $��Part Number��6   �� 5      $��Product Name��6   �� 5      $��Description��6   �� 5      $��Keywords��6   5      �� 5   
   -   5         ��Name$ TxtBoxSearch��5      $��
567,14,0,0q�6(    �� TextWrapping$
 Wrap=�6<   $	��Top=�6w   �� 5   
   -   5        $ 	TxtSearch��5      $
��Left=�6'   $��
399,14,0,0q�6B   $
��Wrap=�6V   $��Search:��6j   $	��Top=�6y   $��0��6�   5       5!      