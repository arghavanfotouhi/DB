   M S B A M L   `   `   `  ����@  <final, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:finalfinal  5   	       final.Window6   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:final     5   	     � Title$  Window6��5   	   $	��450��6   $	��800��6&   .��5	      � ���	#FFFEFFCB � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5      $	��200 �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5#   
   &   System.Windows.Controls.DataGrid  -   5          Name$ datagrid��5#      $��2��6%   $��0��65   $��12��6B   $��10q�6T   ���	#FFDDFAB26`   �� 5&   
   -   5         ��Name$ 	InsertBtn��5&      $��Insert��6$   $��2��65   $��12��6E   $��Center=�6S   $��82��6p   $��	0,23,0,73q�6�   ���	#FFDDFAB26�   �� 5'   
   -   5        $ 	UpdateBtn��5'      $��Update��6$   $��2��65   $��12��6E   $��Right=�6S   $��82��6o   $��
0,21,20,76q�6�   ���	#FFDDFAB26�   �� 5(   
   -   5        $ 	DeleteBtn��5(      $��Delete��6$   $��2��65   $��12��6E   $
��Left=�6S   $��82��6n   $��
24,23,0,73q�6�   ���	#FFDDFAB26�   �� 5+   
   $��Id��6   $��0��6   $��0��6*   �� 5,   
   -   5         ��Name$ Id_txt��5,      $��0��6"   $��1��6/   $	��166��6?   $��22��6K   �� 5.   
   $��	FirstName��6   $��1��6$   $��0��61   �� 5/   
   -   5        $ FirstName_txt��5/      $��1��6)   $��1��66   $	��166��6F   $��22��6R   �� 51   
   $��LastName��6   $��2��6#   $��0��60   �� 52   
   -   5        $ LastName_txt��52      $��2��6(   $��1��65   $	��166��6E   $��22��6Q   �� 54   
   $��
FatherName��6   $��3��6%   $��0��62   �� 55   
   -   5        $ FatherName_txt��55      $��3��6*   $��1��67   $	��166��6G   $��22��6S   �� 57   
   $��Phone��6   $��4��6    $��0��6-   �� 58   
   -	   5        $ 	Phone_txt��58      $��4��6%   $��1��62   $	��166��6B   $��22��6N   �� 5:   
   $��Address��6   $��5��6"   $��0��6/   �� 5;   
   -
   5        $ Address_txt��5;      $��5��6'   $��1��64   $	��166��6D   $��22��6P   �� 5=   
   $��	BirthDate��6   $��6��6$   $��0��61   �� 5>   
   -   5        $ BirthDate_txt��5>      $��6��6)   $��1��66   $	��166��6F   $��22��6R   �� 5@   
   $��MatrialStatus��6   $��7��6(   $��0��65   �� 5A   
   -   5        $ matrialstatus_txt��5A      $��7��6-   $��1��6:   $	��166��6J   $��22��6V   �� 5C   
   $��Duties��6   $��8��6!   $��0��6.   �� 5D   
   -   5        $ 
Duties_txt��5D      $��8��6&   $��1��63   $	��166��6C   $��22��6O   �� 5F   
   $��	Education��6   $��9��6$   $��0��61   �� 5G   
   -   5        $ education_txt��5G      $��9��6)   $��1��66   $	��166��6F   $��22��6R   �� 5I   
   $��Salary��6   $��10��6!   $��0��6/   �� 5J   
   -   5        $ 
Salary_txt��5J      $��10��6&   $��1��64   $	��166��6D   $��22��6P   �� 5L   
   $��EmploymentDate��6   $��11��6)   $��0��67   �� 5M   
   -   5        $ employmentDate_txt��5M      $��11��6.   $��1��6<   $	��166��6L   $��22��6X   �� 5O   
   $��WorkTime��6   $��12��6#   $��0��61   �� 5P   
   -   5        $ WorkTime_txt��5P      $��12��6(   $��1��66   $	��166��6F   $��22��6R   5Q      5R      