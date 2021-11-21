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

  selectedBuildingId: number | null = null;
  selectedObjectId: number | null = null;
  selectedDataFieldId: number | null = null;
  dateRangeInput = new FormGroup({
    startDate: new FormControl(),
    endDate: new FormControl(),
  });

  onSelect(event: any) {
    console.log(event);
  }


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

  getDataFromReading(): void {
    this.dataLoaded = 0;


    if (
      this.dateRangeInput.value.startDate === null || this.dateRangeInput.value.endDate === null
    ) {
      console.error('Error..... ');
      this.isDateRangeValid = false;
      return;
    }

    this.isDateRangeValid = true;
    this._service.getResultsFromReading(this.selectedBuildingId, this.selectedObjectId, this.selectedDataFieldId, this.dateRangeInput.value.startDate, this.dateRangeInput.value.endDate).subscribe((responses: IReading[]) => {
      this.readings = responses;
      this.dataLoaded = this.readings.length;
      let yAxisValue = this.readings.map(x => x.timeStamp);
      let xAxisValue = this.readings.map(x => x.value);


      if (this.isChartCreated) {

        this.chart.data.labels = yAxisValue;
        this.chart.data.datasets[0].data = xAxisValue;
        this.chart.update();
        return;
      }


      this.chart = new Chart("ctx-canvas", {
        type: 'line',
        data: {
          labels: yAxisValue,
          datasets: [{
            label: 'Value',
            borderWidth: 2,
            fill: true,
            data: xAxisValue,
            backgroundColor: 'darkred',
          }]
        }
      });
      this.isChartCreated = true;
    });
  }
}
