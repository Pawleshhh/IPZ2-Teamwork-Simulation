   M S B A M L   `   `   `  ����M  ITeamworkSimulation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:TeamworkSimulation.ViewTeamworkSimulation.View  5      .    (TeamworkSimulation.View.WorkplaceControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5      1local%clr-namespace:TeamworkSimulation.View  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      X TXceed.Wpf.Toolkit, Version=4.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44wpft)http://schemas.xceed.com/wpf/xaml/toolkit  5	         Alto#��[  5        � 	Resources  5        DefaultButtonStyle �� BasedOn �� 
TargetType �� Property �� Value��%}   '��       7  �� 5   
   8   " ��6>   .�5      ��  � ��$ 1q�6'   �� 5       � ��$ 5q�6(   5      5      .��5      �   	DarkShark#��[ 6    � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��9* �6    � ColumnDefinitions 5   
   �� 5      $��4* �6   �� 5      $��1* �6   �� 5      $��4* �6   �� 5      $��1* �6   .+�5"   
   ��  �� Orientation$ 
Horizontal=�6   .+�5#      �� $��40��5$      $��40��5%      ��5&      �� *	AddTeam+ � ToolTip 5'      �� 5(      $��Add new team��6    .��5*      "  FontAwesome.WPF.ImageAwesome  	   Icon$	 Group=�6"   5+      �� 5,      $��40��5-      $��40��5.      ��5/      �� *
RemoveTeam+��50      �� 
 �� ElementName$
 	teamsList�� �� Path$ SelectedItems� 51      �� 52      $��Remove selected team��6    .��54        $	 Remove=�6"   55      �� 56      $��40��57      $��40��58      ��59      �� *
ClearTeams+ 5:      �� 5;      $��Remove all teams��6    .��5=        $	 Trash=�6"   5>      (  "Xceed.Wpf.Toolkit.WatermarkTextBox  5@      -   5          Name$ itemNameTextBox��5A      $��3��5B      $	��100��5C      $��10q�5D        
OxfordBlue#��[ 5E         DefaultWatermarkTextBoxStyle#��[ 5F         	Watermark$
 Name��5H      ��5G      �� *
ItemName+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5H      5J      �� 5L   
   $��1��5M      $��1��5N      $��Center=�5O      $ 
Horizontal=�5P      .+�5Q      �� $��16(�6   $��Count: ��6&   �� 5R      $��16(�6   ��6&   �� *TeamVMs.Count+$ OneWay=�5S      �� 5U   
   $��2��6   $ 
Horizontal=�6%   .+�5V      �� $��0,5,0,0q�5W      $��Center=�5X      $��Remote mode��5Y      $��16(�5Z      #��[  5[       d� 	IsChecked 5\      �� *
IsRemote+$ TwoWay=�5h      �� 5j   
   $��3��5k      $��30��5l      $��30��5m      $��0,5,10,5q�5n      $��Center=�5o      $��Center=�5p      ��5q      �� *!ParentViewModel.RemoveWorkplace+��5r      �� .��5s        $	 TrashOutline=�6   5t      �� 5v   
   -   5         ��Name$ 	teamsList��5w      $��1��5x      $��4��5y      $
��Left=�5z      $	��Top=�5{        Tuna#��[ 5|      
���   �$��0,1,0,0q�5~      $��False��5�       �� SelectionMode$ Multiple=�5�      ��5      �� *	TeamVMs+��5�      �� 5�      .R�5�      �� $
��Left=�5�      $	��Top=�5�      $ 
Horizontal=�5�      5�      ��5�      �� 5�      .R�5�      )   #TeamworkSimulation.View.TeamControl  $
��Left=�5�      $	��Top=�5�       � DataContext 5�      �� 5�      5�      5�      5�      