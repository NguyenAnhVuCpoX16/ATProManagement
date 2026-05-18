import { Component, ViewEncapsulation } from '@angular/core';
import { Toolbar } from '../../../component/toolbar/toolbar';
import {
  ILoadedEventArgs,
  IAccPointRenderEventArgs,
  IAccLoadedEventArgs,
  ChartAllModule,
  AccumulationChartAllModule,
} from '@syncfusion/ej2-angular-charts';

import { Browser } from '@syncfusion/ej2-base';
import { DashboardLayoutModule } from '@syncfusion/ej2-angular-layouts';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.css',
  imports: [Toolbar, DashboardLayoutModule, ChartAllModule, AccumulationChartAllModule],
})

export class Dashboard {

  // ===== Layout =====
  public cellSpacing: number[] = [15, 15];
  public cellAspectRatio: number = Browser.isDevice ? 1 : 0.8;
  public columns: number = Browser.isDevice ? 2 : 8;

  public columnSizeX = Browser.isDevice ? 1 : 5;
  public columnSizeY = Browser.isDevice ? 1 : 2;

  public pieColumn = Browser.isDevice ? 1 : 5;
  public pieSizeX = Browser.isDevice ? 1 : 3;
  public pieSizeY = Browser.isDevice ? 1 : 2;

  public splineRow = Browser.isDevice ? 1 : 4;
  public splineSizeX = Browser.isDevice ? 2 : 8;
  public splineSizeY = Browser.isDevice ? 1 : 3;

  public chartArea = { border: { width: 0 } };

  // ===== COLUMN CHART =====
  public columnChartDataCollection = [
    { Period: "2020", Percentage: 60, TextMapping: "60%" },
    { Period: "2021", Percentage: 56, TextMapping: "56%" },
    { Period: "2022", Percentage: 71, TextMapping: "71%" },
    { Period: "2023", Percentage: 85, TextMapping: "85%" },
    { Period: "2024", Percentage: 73, TextMapping: "73%" }
  ];

  public columnChartData = [
    { Period: "2020", Percentage: 40, TextMapping: "40%" },
    { Period: "2021", Percentage: 44, TextMapping: "44%" },
    { Period: "2022", Percentage: 29, TextMapping: "29%" },
    { Period: "2023", Percentage: 15, TextMapping: "15%" },
    { Period: "2024", Percentage: 27, TextMapping: "27%" }
  ];

  public columnChartprimaryXAxis = {
    valueType: 'Category',
    majorGridLines: { width: 0 }
  };

  public columnChartprimaryYAxis = {
    labelFormat: '{value}%',
    minimum: 0,
    maximum: 100,
    majorTickLines: { width: 0 },
    lineStyle: { width: 0 }
  };

  public columnChartlegendSettings = {
    enableHighlight: true
  };

  public columnChartmarker = {
    dataLabel: {
      visible: true,
      position: 'Middle',
      name: 'TextMapping'
    }
  };

  public chartCornerRadius = {
    topLeft: 4,
    topRight: 4
  };

  public series1Fill = '#2485fa';
  public series2Fill = '#FEC200';

  // ===== PIE CHART =====
  public data = [
    { Product: "TV", Percentage: 12 },
    { Product: "PC", Percentage: 8 },
    { Product: "Laptop", Percentage: 16 },
    { Product: "Mobile", Percentage: 36 },
    { Product: "Camera", Percentage: 11 }
  ];

  public pieTooltipSetting = {
    enable: true
  };

  public pielegendSettings = {
    visible: false
  };

  public dataLabel = {
    visible: true,
    position: 'Outside',
    name: 'Product'
  };

  public palettes = [
    "#61EFCD", "#CDDE1F", "#FEC200", "#CA765A", "#2485FA"
  ];

  public startAngle = 270;
  public endAngle = 270;

  public accumulationload(args: IAccLoadedEventArgs) { }

  public pointRender(args: IAccPointRenderEventArgs) { }

  // ===== SPLINE AREA =====
  public spLineAreaData = [
    { Period: "Jan", Percentage: 3600 },
    { Period: "Feb", Percentage: 6200 },
    { Period: "Mar", Percentage: 8100 },
    { Period: "Apr", Percentage: 5900 },
    { Period: "May", Percentage: 8900 }
  ];

  public spLineAreaData2 = [
    { Period: "Jan", Percentage: 6400 },
    { Period: "Feb", Percentage: 5300 },
    { Period: "Mar", Percentage: 4900 },
    { Period: "Apr", Percentage: 5300 },
    { Period: "May", Percentage: 4200 }
  ];

  public spLineAreaprimaryXAxis = {
    valueType: 'Category'
  };

  public spLineAreaprimaryYAxis = {
    minimum: 0,
    maximum: 12000
  };

  public spLineLegendSettings = {
    enableHighlight: true
  };

  public spLineAreatooltipSettings = {
    enable: true
  };

  public spLineAreaBorder = { width: 2 };
  public spLineAreaBorder1 = { width: 2 };

  public spLineAreaFill = '#2485fa';
  public spLineAreaFill1 = '#FEC200';

  public load(args: ILoadedEventArgs) { }
}
