   M S B A M L   `   `   `  ����G  CH2_Case_Bank, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:H2_Case_BankH2_Case_Bank  5   	       H2_Case_Bank.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:H2_Case_Bank     5   	     � Title$
  Bank��5   	   $	��800��6   $
��1200��6#   .��5	      � $��0,0,-0.4,0.4q�6   ��5
   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FF85B4E8��6    � Offset$ 0Q�61   � 5      $ 	#FF476382��6   $ 0.995Q�61   5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��Kundeoversigt_DataGrid��5   s   $
��Left=�6   $	��561��6.   $��
47,100,0,0q�6;   $	��Top=�6O   $	��741��6g      
IsReadOnly .    HorizontalGridLinesBrush �	#FFBDB5B5   VerticalGridLinesBrush �	#FFF0EDED � Cursor$
 Hand��6a  	   AutoGenerateColumns	 .  ��6o  �� *ReturnCustomers+
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Kunde ID��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *UserID+  5      $ Fornavn��6%    66   �� *	Firstname+  5      $ 	Efternavn��6%    68   �� *
Lastname+  5      $ Opretelses Dato��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6_    6>   �� *CreationDate+6_   5      �� 5   
   -   5        $��SletKunde_Button��5   �   $��
Slet Kunde��6   $
��Left=�6&   $��
39,699,0,0q�6A   $	��Top=�6U   $	��109��6m   $��39��6y   ���	#FF316BB3
�������$
��Bold"�6�   $
 Hand��6�   �� 5   
   -   5        $��Fornavn_Label��5   �   $��Fornavn��6   $
��Left=�6"   $��825,119,0,0q�6=   $	��Top=�6R   ���	#FF144AE06�   �� 5   
   -   5        $��Efternavn_Label��5   �   $��	Efternavn��6   $
��Left=�6$   $��825,150,0,0q�6?   $	��Top=�6T    J� RenderTransformOrigin$ -0.083,0.026&�6l   ���	#FF144AE06�   �� 5   
   -   5        $��Fornavn_TextBox��5   �   $
��Left=�6   $��23��6-   $��927,123,0,0q�69    �� TextWrapping$
 Wrap=�6N   $�� ��6b   $	��Top=�6j   $	��235��6�   6�   �� 5   
   -   5        $��Efternavn_TextBox��5   �   $
��Left=�6   $��23��6-   $��927,154,0,0q�69   $
 Wrap=�6N   $�� ��6b   $	��Top=�6j   $	��235��6�   6�   �� 5   
   -   5        $��Opret_Button��5   �   $��Opret��6   $
��Left=�6!   $��1053,191,0,0q�6<   $	��Top=�6R   $	��109��6j   $��39��6v   ���	#FF316BB3
�������$
��Bold"�6�   $
 Hand��6�   �� 5   
   $��Kundeoversigt��6   $
��Left=�6(   $��	47,58,0,0q�6C   $	��Top=�6V   $	��741��6n   
�������$
��Bold"�6�   $��24(�6�   ��5       �� 5!      $ 0.5,1&�6&   $ 0.5,0&�67   .��5"      � $ 	#FF3B5A65��6#   $ 0Q�65   � 5#      $ 	#FF85B4E8��6#   $ 1Q�65   5$      5&      �� 5'   
   $��Opret Kunde��6   $
��Left=�6&   $��
825,58,0,0q�6A   $	��Top=�6U   $ 0.524,-0.36&�6m   $	��337��6�   
�������$
��Bold"�6�   $��24(�6�   ��5(      �� 5)      $ 0.5,1&�6&   $ 0.5,0&�67   .��5*      � $ 	#FF3B5A65��6#   $ 0Q�65   � 5+      $ 	#FF85B4E8��6#   $ 1Q�65   5,      5.      �� 5/   
   -   5        $��Search_TextBox��5/   �   $
��Left=�6   $��23��6-   $��
565,27,0,0q�69   $
 Wrap=�6M   $�� ��6a   $	��Top=�6i   $	��223��6�   6�   �� 50   
   -	   5         ��Name$ Fornavn_Label_Copy��50   �   $��
Find Kunde��6   $
��Left=�6%   $��
492,27,0,0q�6@   $	��Top=�6T   ���	#FF144AE06�   52      53      