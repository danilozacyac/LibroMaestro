   M S B A M L   `   `   `  ����  LibroMaestro%    LibroMaestro.Tesis.IntegraTesis   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      H DMahApps.Metro, Version=1.2.3.0, Culture=neutral, PublicKeyToken=null9Custom,http://metro.mahapps.com/winfx/xaml/controls  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      p lTelerik.Windows.Controls.RibbonView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a ]Telerik.Windows.Data, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e	 aTelerik.Windows.Controls, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n
 jTelerik.Windows.Controls.GridView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.Navigation, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Itelerik1http://schemas.telerik.com/2008/xaml/presentation    	 
  5      -   5        
�������.��5      �� ���#1ba1e2$��2q�5        �� CornerRadius$  8��5      ._�5   
   � .+�5      )  #MahApps.Metro.Controls.ToggleSwitch  -   5          Name$ ChkEjecutoria��5   "   
 J� Uid$ 2��5   "   $��	20,10,0,0q�5   "   $
��Left=�5   "   $	��Top=�5   "   $��¿Ejecutoria?��5   "      	IsChecked 5   "   �� *TieneEjecutoria+ �� Mode$ TwoWay=�5   "   �� 5      $	��866��6   $	��431��5      $��
20,136,0,0q�5      $
��Left=�5      $	��Top=�5      $.��(Elementos que integran la documentación��5       .��5!      ) 	 #Telerik.Windows.Controls.RadListBox  -   5          Name$ LstIntegracion��5!   %   $��Stretch=�5"   %   $��Stretch=�5#   %   ��5$   %   �� ��5%      �� 5&      .R�5'      �� $��0,5,0,0q�6'   ��5(   '   �� *Descripcion+ d� 	IsChecked 5)   '   �� *
IsSelected+5*      5,      5-      �� 5.      $��
20,572,0,0q�6   $
��Left=�5/      $	��Top=�50      $��Observaciones:��51      $��14(�52      $
��Bold"�53      �� 54      -   5         ��Name$ TxtObservaciones��54      $	��865��55      $��85��56      $��
21,606,0,0q�57      $
��Left=�58      $	��Top=�59       �� TextWrapping$
 Wrap=�5<      ��5:      �� *Observaciones+$ TwoWay=�5<      �� 5=      $��
21,105,0,0q�6   $
��Left=�5>      $	��Top=�5?      $��Archivo escaneado:��5@      �� 5A      -   5        $ TxtSupportFile��5A      $	��203��5B      $��23��5C      $��138,105,0,0q�5D      $
��Left=�5E      $	��Top=�5F      {�.  ��5H      �� *
FileName+$ TwoWay=��� 5J      -   5        	 ��Name$	 
LblNumEjec��5J      $��	20,64,0,0q�5K      $
��Left=�5L      $	��Top=�5M      $��Núm Ejecutorias:��5N      $y�	Collapsed=�5O      /  )Telerik.Windows.Controls.RadNumericUpDown  5P      -   5        
  Name$
 NumEjec��5P   '   $��59��5Q   '   $��24��5R   '   $��
124,64,0,0q�5S   '   $
��Left=�5T   '   $	��Top=�5U   '      	IsInteger . + 	 %Telerik.Windows.Controls.RadRangeBase   Maximum$ 6Q�5W   '      Minimum$ 0Q�5X   '   $y�	Collapsed=�5Y   '      Value 5Z   '   �� *NumEje+$ TwoWay=��� 5\      -   5        $	 LblNumVotos��5\      $��
206,64,0,0q�5]      $
��Left=�5^      $	��Top=�5_      $��Núm. Votos��5`      $y�	Collapsed=�5a        5b      -	   5        $
 NumVotos��5b   '   $��73��5c   '   $��
284,64,0,0q�5d   '   $
��Left=�5e   '   $	��Top=�5f   '    . $ 15Q�5h   '   $ 0Q�5i   '   $y�	Collapsed=�5j   '    5k   '   �� *
NumVotos+$ TwoWay=��� 5m      -
   5         ��Name$ BtnSearchFile��5m      $��26��5n      $��26��5o      $��346,105,0,0q�5p      $
��Left=�5q      $	��Top=�5r      .��5t      �� $5��//LibroMaestro;component/Resources/search_32.png��6   5u        5v      -   5        $ 
ChkMateria��5w   "   $ 5��5v   "   $��
603,10,0,0q�5x   "   $
��Left=�5y   "   $	��Top=�5z   "   $��¿Cambio de materia?��5|   "   $��Normal"�5}   "    5~   "   �� *CambioMateria+$ TwoWay=�5�   "     5�      -   5        $ ChkVotos��5�   "   $ 3��5�   "   $��
206,10,0,0q�5�   "   $
��Left=�5�   "   $	��Top=�5�   "   $��
¿Voto(s)?��5�   "    5�   "   �� *
TieneVotos+$ TwoWay=�5�   "     5�      -   5        $ ChkModificacion��5�   "   $ 4��5�   "   $��
389,10,0,0q�5�   "   $
��Left=�5�   "   $	��Top=�5�   "   $��¿S. Modificación?��5�   "    5�   "   �� *SugModificacion+$ TwoWay=�5�   "     5�      -   5        $ ChkContradiccion��5�   "   $ 6��5�   "   $��
399,58,0,0q�5�   "   $
��Left=�5�   "   $	��Top=�5�   "   $��¿Contradicción?��5�   "    5�   "   �� *PropContradiccion+$ TwoWay=�5�   "     5�      -   5        $ ChkNoPublica��5�   "   $ 7��5�   "   $��
630,58,0,0q�5�   "   $
��Left=�5�   "   $	��Top=�5�   "   $��¿No Publicación?��5�   "    5�   "   �� *	NoPublica+$ TwoWay=�5�   "   5�      5�      5�      