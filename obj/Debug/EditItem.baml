   M S B A M L   `   `   `  ����H  DAlparMoto IMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:AlparMoto_IMSAlparMoto_IMS  5   	       AlparMoto_IMS.EditItem   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:AlparMoto_IMS     5   	     � Title$  Edit Inventory Item��5   	   $	��270��6%   $	��240��62   $	��270��6>   $	��270��6N   $	��240��6^   $	��240��6m    � Icon$ /Alpar-MotoTech-icon.ico��6}    � 
ResizeMode$ NoResize=�6�   .��5	      � .+�5
   
   �� -   5         ��Name$ 
ButtonEdit��5
      $
��Edit��6%   $
��Left=�64   $��	10,0,0,10q�6O   $��Bottom=�6b   $��19��6}   $��90��6�   $��2��6�   6�   �� 5   
   -   5        $ ButtonCancel��5      $��Cancel��6'   $��Right=�68   $��	0,0,10,10q�6T   $��Bottom=�6g   $��19��6�   $��90��6�   $��1��6�   6�   �� 5   
   -   5         ��Name$ txtBlockPartNumber��5      $
��Left=�60   $��10,8,0,0q�6K   $
��Wrap=�6]   $��Part Number��6q   $	��Top=�6�   �� 5   
   -   5         ��Name$ txtBoxPartNumber��5      $��Right=�6,   $��0,8,10,0q�6H    �� TextWrapping$
 Wrap=�6Z   $�� ��6n   $	��Top=�6v   $	��120��6�   $��1��6�   �� 5   
   -   5        $ txtBlockProductName��5      $
��Left=�61   $��	10,31,0,0q�6L   $
��Wrap=�6_   $��Product Name��6s   $	��Top=�6�   $��2��6�   �� 5   
   -   5        $ txtBoxProductName��5      $��Right=�6-   $��	0,31,10,0q�6I   $
 Wrap=�6\   $�� ��6p   $	��Top=�6x   $	��120��6�   $��1��6�   �� 5   
   -   5        $ txtBlockStockAmount��5      $
��Left=�61   $��	10,54,0,0q�6L   $
��Wrap=�6_   $��Stock Amount��6s   $	��Top=�6�   $��2��6�   �� 5   
   -   5        $ txtBoxStockAmount��5      $��Right=�6-   $��	0,54,10,0q�6I   $
 Wrap=�6\   $�� ��6p   $	��Top=�6x   $	��120��6�   $��1��6�   �� 5   
   -	   5        $ txtBlockDescription��5      $
��Left=�61   $��
10,151,0,0q�6L   $
��Wrap=�6`   $��Description��6t   $	��Top=�6�   �� 5   
   -
   5        $ txtBoxDescription��5      $��Right=�6-   $��
0,151,10,0q�6I   $
 Wrap=�6]   $�� ��6q   $	��Top=�6y   $	��120��6�   $��1��6�   �� 5   
   -   5        $ txtBlockKeywords��5      $
��Left=�6.   $��
10,174,0,0q�6I   $
��Wrap=�6]   $��Keywords��6q   $	��Top=�6�   �� 5   
   -   5        $ txtBoxKeywords��5      $��Right=�6*   $��
0,174,10,0q�6F   $
 Wrap=�6Z   $�� ��6n   $	��Top=�6v   $	��120��6�   $��1��6�   �� 5   
   -   5        $ txtBlockDateReceived��5      $
��Left=�62   $��	10,85,0,0q�6M   $
��Wrap=�6`   $��Date Received��6t   $	��Top=�6�   $��2��6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ datePickerDateReceived��5      $��Right=�65   $��	0,77,10,0q�6Q   $	��Top=�6d   $	��120��6|   $��1��6�      SelectedDateFormat$
 Long=�6�   �� 5   
   -   5        $ txtBlockPrice��5      $
��Left=�6+   $��
10,106,0,0q�6F   $
��Wrap=�6Z   $��Price��6n   $	��Top=�6{   �� 5   
   -   5        $ txtBoxPrice��5      $��Right=�6'   $��
0,106,10,0q�6C   $
 Wrap=�6W   $�� ��6k   $	��Top=�6s   $	��120��6�   $��1��6�   �� 5   
   -   5        $ txtBlockRetailPrice��5      $
��Left=�61   $��
10,129,0,0q�6L   $
��Wrap=�6`   $��Retail Price��6t   $	��Top=�6�   �� 5   
   -   5        $ txtBoxRetailPrice��5      $��Right=�6-   $��
0,129,10,0q�6I   $
 Wrap=�6]   $�� ��6q   $	��Top=�6y   $	��120��6�   $��1��6�   5      5      