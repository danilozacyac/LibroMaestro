   M S B A M L   `   `   `  ����G  CLibroMaestro, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:LibroMaestro.ConverterLibroMaestro.Converter  5      +clr-namespace:LibroMaestroLibroMaestro  5      E AUIControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:UIControls;assembly=UIControls
UIControls 5          LibroMaestro.MainWin   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      ;
Converters$clr-namespace:LibroMaestro.Converter     5      3CustomColumnclr-namespace:LibroMaestro     5      C
UIControls,clr-namespace:UIControls;assembly=UIControls     5      p lTelerik.Windows.Controls.RibbonView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a ]Telerik.Windows.Data, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e	 aTelerik.Windows.Controls, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n
 jTelerik.Windows.Controls.GridView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.Navigation, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Itelerik1http://schemas.telerik.com/2008/xaml/presentation    	 
  5      -   5        $	��900��5      $	��500��5	      $�� ��5
      )  #Telerik.Windows.Controls.WindowBase    WindowState$  	Maximized=�5       � 	Resources 5         ObrasChildTemplate �� ItemsSource �� Orientation  CategoryTemplate �� ItemTemplate8 	 2Telerik.Windows.Controls.Windows8ResourceExtension� 	 �Telerik.Windows.Controls.ThemeResourceExtension`1[[Telerik.Windows.Controls.Windows8ResourceKey, Telerik.Windows.Controls, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7]]   ResourceKey? 	 9Telerik.Windows.Controls.Windows8ResourceKeyTypeConverter.  (Telerik.Windows.Controls.RadTreeViewItem �� 
TargetType �� Property �� Value/   )LibroMaestro.Converter.TipoTesisConverter  tipoTesisConv��%'  &	        &	 �     7   '  �    &	 �    �� 5   
    6>   �� *OrganismosLibro+.R�5      �� $ 
Horizontal=�6   .+�5      �� $
��Wrap=�67   ��6   �� *	Organismo+67   5      5      �� 5   
   8    5   #   �� *OrganismosLibro+.R�5      �� $ 
Horizontal=�6   .+�5      �� $��2q�6   $��Center=�5      ��5        $ MarkerBrush ��5      �� *Descripcion+5      5      �� 5!   
   "  6   .�5"      ��  �@ 
IsExpanded . 6+   5#        5%   
   6(   5'      .��5)      � 	 � RowDefinitions	 5*   
   �� 5+      $
��Auto �6   �� 5,      $��* �6   .+�5.   
   ,  &Telerik.Windows.Controls.RadRibbonView  $	��Top=�6    "
   ApplicationButtonVisibility$
 	Collapsed=�5/          ApplicationName$% Libros electrónicos de la CCST��50       .@�51      +  %Telerik.Windows.Controls.RadRibbonTab  $��General��6#   .@�52      -	  'Telerik.Windows.Controls.RadRibbonGroup	  -   5         	 Name$ GrpTesis��52   )   $��Tesis��6;   .@�53      .
  (Telerik.Windows.Controls.RadRibbonButton
  -   5         
 Name$ RBtnAddTesis��53   .   $��Agregar��55   .    
  
LargeImage$( "Resources/1425495838_add-notes.png��56   .    
  Size$ Large=�57   .   
  58      -   5        $ RBtnVerLibro��58   .   $��	Ver Libro��5:   .   $ Resources/pdf_128.png��5;   .   $ Large=�5<   .   5=      5>      5?      � 5A   
   $��1��6    � ColumnDefinitions 5B      �� 5C      $	��.3* �6#   �� 5D      $��5 �6#   �� 5E      $��* �6#   .+�5G      *  $Telerik.Windows.Controls.RadTreeView  -   5          Name$ treeCircuito��5G   "   $��0,25,0,0q�5H   "   $��Stretch=�5I   "   $��Stretch=�5J   "   #��[ 5K   "   ��5L   "   �� 5M   "     UIControls.SearchTextBox  5O      -   5          Name$ 	TxtSearch��5O   '   $��0q�5P   '   $��Stretch=�5Q   '   $	��Top=�5R   '      	LabelText$ Buscar por organismo...��5S   '   5T   '   �� 5V      $��1��6   $��Stretch=�5W      $��Stretch=�5X      � 5Z      $��2��6   	 5[      �� 5\      $��50 �6$   �� 5]      $��* �6$   .+�5`      * 
 $Telerik.Windows.Controls.RadGridView  -   5          Name$ GTesis��5`   &   $��1��5a   &   $��Stretch=�5b   &   $��Stretch=�5c   &   ; 
 5Telerik.Windows.Controls.GridView.GridViewDataControl   AutoGenerateColumns .     CanUserDeleteRows .     CanUserInsertRows .     
IsReadOnly .    RowIndicatorVisibility$ 	Collapsed=�5i   &      ShowGroupPanel .  *  $Telerik.Windows.Controls.DataControl   ItemsSource 5h   &   ��    Columns 5l      !   LibroMaestro.MyColumnNumber  5m      - 
 'Telerik.Windows.Controls.GridViewColumn   Width? 
 9Telerik.Windows.Controls.GridView.GridViewLengthConverter$ 30 66     ColumnaNumerica   	CellStyle# [ 5n   6      Header$ #��5o   6   1 
 +Telerik.Windows.Controls.GridViewDataColumn  5p      $	 100 65   6 
 0Telerik.Windows.Controls.GridViewBoundColumnBase    Header$  Reg. Digital��5r   5   !   IsFilterable! .  "   DataMemberBinding" 5q   5   �� *Ius+5s   5     5t      $ * 65   $  Rubro��5v   5   ! .  " 5u   5   �� *Rubro+5w   5     5x      $	 120 65   $  C. Identificación��5z   5   ! .  " 5y   5   �� *Clave+5{   5     5|      $ 80 65   $  Carpeta��5~   5   " 5}   5   �� *
NumCarpeta+5~   5     5�      $ 80 65   $  Fojas��5�   5   ! .  " 5�   5   �� *Fojas+5�   5   #   RowStyle# 5�      �� 5�      3 
 -Telerik.Windows.Controls.GridView.GridViewRow"  6    .�5�      ��  � �� 6;   �� *Tatj+$ �� 	Converter#$ [ 5�      5�      5�      5�      5�      5�      