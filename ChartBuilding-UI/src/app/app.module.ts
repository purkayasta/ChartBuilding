import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



import { MatNativeDateModule } from '@angular/material/core';
import { MaterialModules } from 'src/material.module';
import { HttpClientModule } from '@angular/common/http';
import { CommonService } from './services/common-service.service';


@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    MatNativeDateModule,
    ReactiveFormsModule,
    MaterialModules,
    HttpClientModule
  ],
  providers: [CommonService],
  bootstrap: [AppComponent],
})
export class AppModule { }
