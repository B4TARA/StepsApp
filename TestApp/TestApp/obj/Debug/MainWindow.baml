   M S B A M L   `   `   `  ����U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf  5   	   B >TestApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:TestApp.ConvertersTestApp.Converters 5   	   7 clr-namespace:TestApp.ViewModelsTestApp.ViewModels 5   	      TestApp.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QScottPlot.WPF, Version=4.1.45.0, Culture=neutral, PublicKeyToken=e53b06131e34a3aaR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5   	   2local clr-namespace:TestApp.Converters     5   	   7
viewmodels clr-namespace:TestApp.ViewModels     5   	     � Title$  
MainWindow��5   	   $	��700��6   $
��1200��6)   .��5      � 
������ � ColumnDefinitions 5   
   �� 5      $	��44* �6   �� 5      $
��158* �6   �� 5      $
��378* �6   �� 5      $	��35* �6   �� 5      $
��534* �6   �� 5      $	��44* �6    � RowDefinitions 5   
   �� 5      $	��22* �6   �� 5      $	��50* �6   �� 5      $	��24* �6   �� 5      $
��514* �6   �� 5      $	��10* �6   �� 5      $	��29* �6   �� 5      $	��22* �6   .+�5#   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 	DataGrid0��5#         AutoGenerateColumns . 
�������$��1��6�   $��3��6�   $��2��6�   $��	0,0,0,2.6q�6�   ��6&   ��  �� Path$ 
UsersMonth� �� SelectedIndex 6N   �� *SelectedIndex+ � 	Resources 5$      %  TestApp.Converters.RowConverter   RowConverter��%   &	          5%      6%   5&         RowStyle 5'      �� 5(      	 �� 
TargetType)  #System.Windows.Controls.DataGridRow"	  6   .�5)      �� 
 �� Property
 � �� �� Value 63   ��  �� 	Converter# [  5*      5,      � 5/   
   
�������$��3��6&   $��3��67   $��3��6D   $��35,0,43.6,2.6q�6X   .+�50      #   LiveCharts.Wpf.CartesianChart  &    LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$
 None=�6E      Series 6!   �� *SeriesCollection+   AxisY 52         LiveCharts.Wpf.Axis     Title$ Steps��6   60      AxisX 55        $ Month��6      Labels 6-   �� *Labels+   	Separator 56         LiveCharts.Wpf.Separator  57         Step$ 1Q�6,   59      5;      5<      � 5>   
   
�������$��1��6&   $��1��66   $��	0,0.6,0,0q�6C   $��2��6V   .+�5?      �� $-��'Список пользователей��6    �� TextAlignment$ Center=�64   $��Center=�6K   $��18(�6f   $��Italic$�6t   5@      � 5C   
   
�������$��3��6&   $��1��67   $��3��6D   $��35,0.6,43.6,0q�6X   .+�5D      �� $E��?График по выбранному пользователю��6   $ Center=�6A   $��Center=�6X   $��18(�6s   $��Italic$�6�   5E      �� 5F   
   $��Импорт��6   $��1��6=   $��5��6M   ��6"   �� *Import+6M   5G      5I      