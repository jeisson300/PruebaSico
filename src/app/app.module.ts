import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { ListComponent } from './Students/list/list.component';
import { FormsModule } from '@angular/forms';
import { ModalComponent } from './Students/modal/modal.component';

@NgModule({
  declarations: [AppComponent, ListComponent, ModalComponent],
  imports: [BrowserModule, HttpClientModule, FormsModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
