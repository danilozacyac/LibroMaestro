   M S B A M L   `   `   `  ����G  CLibroMaestro, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:LibroMaestro.TesisLibroMaestro.Tesis  5      "    LibroMaestro.Tesis.TesisMgmt   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      2local clr-namespace:LibroMaestro.Tesis     5      p lTelerik.Windows.Controls.RibbonView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a ]Telerik.Windows.Data, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n	 jTelerik.Windows.Controls.GridView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p
 lTelerik.Windows.Controls.Navigation, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Itelerik1http://schemas.telerik.com/2008/xaml/presentation     	 
 5      -   5        $
��1000��5      $	��870��5      $��Tesis��5      ( 
 "Telerik.Windows.Controls.RadWindow    WindowStartupLocation$  CenterScreen=�5
      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��60 �6   .+�5   
   #   LibroMaestro.Tesis.DatosTesis  -   5          Name$ UcDatos��5      $��15q�5      $��Stretch=�5      $��Stretch=�5      %   LibroMaestro.Tesis.IntegraTesis  5   
   -   5          Name$ 	UcIntegra��5      $��15q�5      $��Stretch=�5      $��Stretch=�5      $y�	Collapsed=�5      �� 5   
   -   5         ��Name$ 
BtnGuardar��5      $��1��5      $	��105��5      $��28��5      $��
750,10,0,0q�5      $
��Left=�5      $	��Top=�5       $��	Siguiente��5"         
BlueButton#��[  5#      �� 5$   
   -   5        $ BtnAnterior��5$      $��1��5%      $	��105��5&      $��28��5'      $��
640,10,0,0q�5(      $
��Left=�5)      $	��Top=�5*      $��Anterior��5,      #��[  5-      $y�	Collapsed=�5.      �� 5/   
   -   5        $ BtnCancelar��5/      $��1��50      $	��105��51      $��28��52      $��
860,10,0,0q�53      $
��Left=�54      $	��Top=�55      $��Cancelar��57      #��[  58      59      5:      