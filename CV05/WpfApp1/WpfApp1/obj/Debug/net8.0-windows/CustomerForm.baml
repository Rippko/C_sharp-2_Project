   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.CustomerForm   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	     � Title$  
Zákazník��5   	   $	��250��6   $	��800��6'    � 	Resources 5	        WpfApp1.MyConverter 
  myConv�� 5
   
   %   &	          5      6    5      .��5      �� .+�5   
   ]� $��10q�6   .+�5      �� $��Jméno��6   �� 5      ��6   �� *	FirstName+ �� 	Converter# [  5      ]� 5   
   $��10q�6   .+�5      �� $��Příjmení��6   �� 5      ��6   �� *
LastName+5      ]� 5   
   $��10q�6   .+�5      �� $
��Věk��6   �� 5      ��6   �� *Age+5      �� 5   
   $��Uložit��6   $��10q�6"   5      5      