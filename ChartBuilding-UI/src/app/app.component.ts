import { Component, OnInit } from '@angular/core';
import { Chart, ChartConfiguration, registerables } from 'chart.js';
import { IBulding } from './models/IBuilding';
import { IObject } from './models/IObject';
import { IDataField } from './models/IDataField';
import { CommonService } from './services/common-service.service';
import { IReading } from './models/IReading';
import { FormControl, FormGroup } from '@angular/forms';
import { FiveDayRangeSelectionStrategy } from './rules/date-picker-rule';
import { MAT_DATE_RANGE_SELECTION_STRATEGY } from '@angular/material/datepicker';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [
    {
      provide: MAT_DATE_RANGE_SELECTION_STRATEGY,
      useClass: FiveDayRangeSelectionStrategy
    }
  ]
})
export class AppComponent implements OnInit {
  title = 'Building Chart';
  buildings: IBulding[] = [];
  objects: IObject[] = [];
  dataFields: IDataField[] = [];
  readings: IReading[] = [];
  isDateRangeValid: boolean = true;

  chart: any = [];
  chartConfiguration: ChartConfiguration | null = null;
  isChartCreated = false;
  dataLoaded: number = 0;
  isDataFound: boolean = true;

  previousStartDate: any;
  previousEndDate: any;

  yAxisValue: any;
  xAxisValue: any;
  selectedBuildingId: number | null = null;
  selectedObjectId: number | null = null;
  selectedDataFieldId: number | null = null;
  dateRangeInput = new FormGroup({
    startDate: new FormControl(),
    endDate: new FormControl(),
  });

  constructor(private _service: CommonService) {
    Chart.register(...registerables);
  }

  ngOnInit(): void {
    this.initBuidings();
    this.initDataFields();
    this.initObjects();
  }
  initBuidings(): void {
    this._service.getBuildings().subscribe((responses: IBulding[]) => {
      this.buildings = responses;
    });
  }
  initObjects(): void {
    this._service.getObjects().subscribe((responses: IObject[]) => {
      this.objects = responses;
    });
  }
  initDataFields(): void {
    this._service.getDataFields().subscribe((responses) => {
      this.dataFields = responses;
    });
  }

  resetFilter(): void {
    this.dataLoaded = 0;
    this.selectedBuildingId = null;
    this.selectedDataFieldId = null;
    this.selectedObjectId = null;
    this.dateRangeInput.reset();
    if (this.isChartCreated)
      this.chart.destroy();
    this.isChartCreated = false;
    this.isDataFound = true;
    this.isDateRangeValid = true;
  }

  searchBtnClickEvent(): void {
    this.dataLoaded = 0;

    if (
      this.dateRangeInput.value.startDate === null || this.dateRangeInput.value.endDate === null
    ) {
      console.error('Error..... ');
      this.isDateRangeValid = false;
      return;
    }

    this.isDateRangeValid = true;

    if (this.dateRangeInput.value.startDate === this.previousStartDate && this.dateRangeInput.value.endDate === this.previousEndDate) {

      let filterList = this.readings.filter(x => (this.selectedBuildingId === null || x.buildingId === this.selectedBuildingId) && (this.selectedDataFieldId === null || x.dataFieldId === this.selectedDataFieldId) && (this.selectedObjectId === null || x.objectId === this.selectedObjectId));

      console.log(filterList);
      // this.readings = filterList;

      this.updateValuesForChart(filterList, () => this.chart.update());

      // this.chart.update();

      return;
    }

    this.previousStartDate = this.dateRangeInput.value.startDate;
    this.previousEndDate = this.dateRangeInput.value.endDate;

    this.getResultFromReading();
  }

  updateValuesForChart(srcList: IReading[], callback: any) {

    this.dataLoaded = srcList.length;

    this.yAxisValue = srcList.map(x => x.timeStamp);
    this.xAxisValue = srcList.map(x => x.value);

    if (this.dataLoaded < 1)
      this.isDataFound = false;
    else
      this.isDataFound = true;

    if (this.isChartCreated) {
      this.chart.data.labels = this.yAxisValue;
      this.chart.data.datasets[0].data = this.xAxisValue;
    }

    console.log("Callbacking this ", callback);

    callback();
  }

  getResultFromReading(): void {
    this._service.getResultsFromReading(this.selectedBuildingId, this.selectedObjectId, this.selectedDataFieldId, this.dateRangeInput.value.startDate, this.dateRangeInput.value.endDate).subscribe((responses: IReading[]) => {

      this.readings = responses;
      this.updateValuesForChart(this.readings, () => {

        if (this.isChartCreated) {
          this.chart.update();
          return;
        }

        this.drawChart();
      });

    });
  }

  drawChart(): void {
    this.isChartCreated = true;

    this.chart = new Chart("ctx-canvas", {
      type: 'line',
      options: {
        responsive: true
      },
      data: {
        labels: this.yAxisValue,
        datasets: [{
          order: 1,
          tension: 0.7,
          showLine: true,
          label: 'Value',
          borderWidth: 2,
          fill: false,
          data: this.xAxisValue,
          backgroundColor: '#27CAA1',
        }]
      }
    });
  }
}
