   M S B A M L   `   `   `  ���� M  ITeamworkSimulation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:TeamworkSimulation.ViewTeamworkSimulation.View  .    (TeamworkSimulation.View.WorkplaceControl   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  1local%clr-namespace:TeamworkSimulation.View  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  X TXceed.Wpf.Toolkit, Version=4.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44wpft)http://schemas.xceed.com/wpf/xaml/toolkit     Alto#��[    � 	Resources    DefaultButtonStyle �� BasedOn �� 
TargetType �� Property �� Value��%J   '��       7  �� 8   " ��.���  � ��$ 1q���  � ��$ 5q�.���   	DarkShark#��[  � RowDefinitions �� $��40 ��� $��9* � � ColumnDefinitions �� $��4* ��� $��1* ��� $��4* ��� $��1* �.+���  �� Orientation$ 
Horizontal=�.+��� $��40��$��40������ *	AddTeam+ � ToolTip �� $��Add new team��.��"  FontAwesome.WPF.ImageAwesome  	   Icon$	 Group=��� $��40��$��40������ *
RemoveTeam+���� 
 �� ElementName$
 	teamsList�� �� Path$ SelectedItems� �� $��Remove selected team��.��  $	 Remove=��� $��40��$��40������ *
ClearTeams+ �� $��Remove all teams��.��  $	 Trash=�(  "Xceed.Wpf.Toolkit.WatermarkTextBox  -     Name$ itemNameTextBox��$��3��$	��100��$��10q�  
OxfordBlue#��[    DefaultWatermarkTextBoxStyle#��[    	Watermark$
 Name������ *
ItemName+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� $��1��$��1��$��Center=�$ 
Horizontal=�.+��� $��16(�$��Count: ���� $��16(����� *TeamVMs.Count+$ OneWay=��� $��2��$ 
Horizontal=�.+��� $��0,5,0,0q�$��Center=�$��Remote mode��$��16(�#��[   d� 	IsChecked �� *
IsRemote+$ TwoWay=��� $��3��$��30��$��30��$��0,5,10,5q�$��Center=�$��Center=����� *!ParentViewModel.RemoveWorkplace+���� .��  $	 TrashOutline=��� -    ��Name$ 	teamsList��$��1��$��4��$
��Left=�$	��Top=�  Tuna#��[ 
���   �$��0,1,0,0q�$��False�� �� SelectionMode$ Multiple=����� *	TeamVMs+���� .R��� $
��Left=�$	��Top=�$ 
Horizontal=����� .R�)   #TeamworkSimulation.View.TeamControl  $
��Left=�$	��Top=� � DataContext �� 