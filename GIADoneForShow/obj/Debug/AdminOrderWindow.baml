   M S B A M L   `   `   `  ����I  EGIADoneForShow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:GIADoneForShowGIADoneForShow  5   	   %    GIADoneForShow.AdminOrderWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:GIADoneForShow     5   	     � Title$  AdminOrderWindow��5   	   $	��450��6"   $	��800��6/   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $��50 �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridOrder��5         AutoGenerateColumns .     
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$	 №��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 30 6G   1  +System.Windows.Controls.DataGridBoundColumn   Binding 60   �� *id+6G     5      $ Тип��6%   $ * 6Y    62   �� *EquipmentType.name+6Y     5      $ Модель��6%   $ * 6]    65   �� *EquipmentModel.name+6]     5      $ Деффект��6%   $ * 6W    66   �� *Deffect.name+6W     5      $ Статус��6%   $ * 6U    65   �� *Status.name+6U   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ * 6)   	   CellTemplate	 5      �� 5      .R�5      �� 
 ��Name$
 editOrderButton��6%   -   5        $��Подробнее��5      5      5      5!      5$      �� 5&   
   -   5        $
 
backButton��5&      $��
Назад��5'   	   $��1��5(   	   $
��Left=�5)   	   $��20(�5*   	   $
��20 5q�5+   	   $��4q�5,   	   5-   	   50      51      