   M S B A M L   `   `   `  ���� M  ITeamworkSimulation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:TeamworkSimulation.ViewTeamworkSimulation.View  )    #TeamworkSimulation.View.TeamControl   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  1local%clr-namespace:TeamworkSimulation.View  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  X	 TXceed.Wpf.Toolkit, Version=4.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44wpft)http://schemas.xceed.com/wpf/xaml/toolkit 	 $	��470��   	DarkShark#��[  $��2q�  Alto#��[ ���� *ColorVM.SelectedColor+  defaultToNullExt  �� 	Converter#  [  	 Shark �� FallbackValue# [  � 	Resources  �� 
TargetType �� Property �� Value  DefaultButtonStyle �� BasedOn  DefaultComboBoxStyle��%�   '��       '�� #     7  '�� _     7  �� " ��.���  � ��$ 16(��� 8   " ��.���  � ��$ 2q���  � ��$ 4q��� 8   " ��.���  � ColumnDefinitions �� $��3* ��� $
��3.5* ��� $
��3.5* � � RowDefinitions �� $
��0.5* ��� $
��0.5* ��� $��9* �.+��� $��2��$
��Left=�$��Center=�	 �� Orientation$	 
Horizontal=�.+��� $��40��$��40������ *AddTeamMember+
 � ToolTip
 �� $��12(�$��Add new member��.��"  FontAwesome.WPF.ImageAwesome     Icon$
 Male=��� $��40��$��40������ *RemoveTeamMember+����  �� ElementName$ teamMembersList�� �� Path$ SelectedItems�
 �� $��12(�$��Remove selected member��.��  $ Remove=��� $��40��$��40������ *ClearTeamMembers+
 �� $��12(�$��Remove all members��.��  $ Trash=��� $��1��$��10q�$��Center=�#��[ 
���   �$��1q� �� CornerRadius$ 2��._��� $	 
Horizontal=�.+��� $��15(�$��Members count: ���� $��15(����� *TeamMembers.Count+ �� Mode$ OneWay=�( 	 "Xceed.Wpf.Toolkit.WatermarkTextBox  -     Name$ itemNameTextBox��$��1��$��1��$��10q�   DefaultWatermarkTextBoxStyle#��[    	Watermark$
 Name������ *
ItemName+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� $��1��$��2��$
��10,0q�$��Center=�$	 
Horizontal=�.+�,   &TeamworkSimulation.View.ColorsComboBox  -     Name$ colorsComboBox��$	��100�� � DataContext �� *	ColorVM+�� $��20��$��8q����� $ colorsComboBox��$ Height����� *
ApplyColor+.��  $ 
PaintBrush=��� $��0��$��2��$��Right=�$��Center=�$	 
Horizontal=�.+��� $��30��$��30��$��0,5,10,5q����� *ParentViewModel.CopyTeam+���� .��  $
 Copy=��� $��30��$��30��$��0,5,10,5q����� *ParentViewModel.RemoveTeam+���� .��  $ TrashOutline=��� $��Center=�$��Center=� d� 	IsChecked �� *
UseModel+$ TwoWay=��� -    ��Name$ teamMembersList��$��2��$��3��  
LightShark#��[ #��[  $��2q� �� SelectionMode$ Multiple=����� *TeamMembers+$ OneWay=�*  $Microsoft.Xaml.Behaviors.Interaction   	Behaviors .   (TeamworkSimulation.View.IgnoreMouseWheel  ���� .R�(   "TeamworkSimulation.View.TeamMember   �� 