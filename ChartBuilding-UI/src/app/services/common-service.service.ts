import { HttpClient, HttpParams, HttpStatusCode } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IBulding } from '../models/IBuilding';
import { IDataField } from '../models/IDataField';
import { IObject } from '../models/IObject';
import { IReading } from '../models/IReading';

@Injectable({
  providedIn: 'root',
})
export class CommonService {
  constructor(private _httpClient: HttpClient) {}

  getBuildings(): Observable<IBulding[]> {
    return this._httpClient.get<IBulding[]>(
      environment.baseApiUrl + 'building/'
    );
  }

  getObjects(): Observable<IObject[]> {
    return this._httpClient.get<IObject[]>(environment.baseApiUrl + 'object/');
  }

  getDataFields(): Observable<IDataField[]> {
    return this._httpClient.get<IDataField[]>(
      environment.baseApiUrl + 'datafield/'
    );
  }

  getResultsFromReading(
    buildingId: number | null,
    objectId: number | null,
    datatFieldId: number | null,
    startDate: Date | null,
    endDate: Date | null
  ): Observable<IReading[]> {

    let urlParams = `?buildingId=${buildingId}&objectId=${objectId}&datatFieldId=${datatFieldId}&startDate=${startDate?.toDateString()}&endDate=${endDate?.toDateString()}`;

    return this._httpClient.get<IReading[]>(
      environment.baseApiUrl + `reading/` + urlParams
    );
  }
}
