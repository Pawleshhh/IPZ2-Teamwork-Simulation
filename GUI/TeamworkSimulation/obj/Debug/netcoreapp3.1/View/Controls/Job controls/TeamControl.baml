   M S B A M L   `   `   `  ����M  ITeamworkSimulation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:TeamworkSimulation.ViewTeamworkSimulation.View  5      )    #TeamworkSimulation.View.TeamControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      1local%clr-namespace:TeamworkSimulation.View  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5	      X	 TXceed.Wpf.Toolkit, Version=4.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44wpft)http://schemas.xceed.com/wpf/xaml/toolkit 	 5
      $	��470��5         	DarkShark#��[  5      $��2q�5        Alto#��[ 5      ��5      �� *ColorVM.SelectedColor+  defaultToNullExt  �� 	Converter#  [  	 Shark �� FallbackValue# [  � 	Resources 5       �� 
TargetType �� Property �� Value  DefaultButtonStyle �� BasedOn  DefaultComboBoxStyle��%�   '��       '�� H     7  '�� �     7  �� 5   
   " ��6   .�5      ��  � ��$ 16(�6)   5      �� 5   
   8   " ��6>   .�5      ��  � ��$ 2q�6'   �� 5       � ��$ 4q�6(   5      �� 5   
   8   " ��6@   5      .��5      �  � ColumnDefinitions 5   
   �� 5       $��3* �6   �� 5!      $
��3.5* �6   �� 5"      $
��3.5* �6    � RowDefinitions 5$   
   �� 5%      $
��0.5* �6   �� 5&      $
��0.5* �6   �� 5'      $��9* �6   .+�5*   
   �� $��2��5+      $
��Left=�5,      $��Center=�5-      	 �� Orientation$	 
Horizontal=�5.      .+�5/      �� $��40��50      $��40��51      ��52      �� *AddTeamMember+
 � ToolTip
 53      �� 54      $��12(�6    $��Add new member��6.   .��56      "  FontAwesome.WPF.ImageAwesome     Icon$
 Male=�6"   57      �� 58      $��40��59      $��40��5:      ��5;      �� *RemoveTeamMember+��5<      ��  �� ElementName$ teamMembersList�� �� Path$ SelectedItems�
 5=      �� 5>      $��12(�6    $��Remove selected member��6.   .��5@        $ Remove=�6"   5A      �� 5B      $��40��5C      $��40��5D      ��5E      �� *ClearTeamMembers+
 5F      �� 5G      $��12(�6    $��Remove all members��6.   .��5I        $ Trash=�6"   5J      5K      �� 5M   
   $��1��5N      $��10q�5O      $��Center=�5P      #��[ 5Q      
���   �$��1q�5S       �� CornerRadius$ 2��5T      ._�5U      �� $	 
Horizontal=�6   .+�5V      �� $��15(�6   $��Members count: ��6*   �� 5W      $��15(�6   ��6*   �� *TeamMembers.Count+ �� Mode$ OneWay=�5X      5Y      ( 	 "Xceed.Wpf.Toolkit.WatermarkTextBox  5[   
   -   5          Name$ itemNameTextBox��5\      $��1��5]      $��1��5^      $��10q�5_         DefaultWatermarkTextBoxStyle#��[ 5`         	Watermark$
 Name��5b      ��5a      �� *
ItemName+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5b      �� 5d   
   $��1��5e      $��2��5f      $
��10,0q�5g      $��Center=�5h      $	 
Horizontal=�5i      .+�5j      ,   &TeamworkSimulation.View.ColorsComboBox  -   5          Name$ colorsComboBox��5k      $	��100��5l       � DataContext 5m      �� *	ColorVM+�� 5n      $��20��5o      $��8q�5q      ��5p      �� $ colorsComboBox��$ Height���5r      �� *
ApplyColor+.��5s        $ 
PaintBrush=�6"   5t      5u      �� 5w   
   $��0��5x      $��2��5y      $��Right=�5z      $��Center=�5{      $	 
Horizontal=�5|      .+�5}      �� $��30��5~      $��30��5      $��0,5,10,5q�5�      ��5�      �� *ParentViewModel.CopyTeam+��5�      �� .��5�        $
 Copy=�6"   5�      �� 5�      $��30��5�      $��30��5�      $��0,5,10,5q�5�      ��5�      �� *ParentViewModel.RemoveTeam+��5�      �� .��5�        $ TrashOutline=�6"   5�      �� 5�      $��Center=�5�      $��Center=�5�       d� 	IsChecked 5�      �� *
UseModel+$ TwoWay=�5�      �� 5�   
   -   5         ��Name$ teamMembersList��5�      $��2��5�      $��3��5�        
LightShark#��[ 5�      #��[  5�      $��2q�5�       �� SelectionMode$ Multiple=�5�      ��5�      �� *TeamMembers+$ OneWay=�*  $Microsoft.Xaml.Behaviors.Interaction   	Behaviors 5�      .   (TeamworkSimulation.View.IgnoreMouseWheel  5�      ��5�      �� 5�      .R�5�      (   "TeamworkSimulation.View.TeamMember   6'   �� 5�      5�      5�      5�      