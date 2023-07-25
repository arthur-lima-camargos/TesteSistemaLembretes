import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ButtonModule } from 'primeng/button';
import { CalendarModule } from 'primeng/calendar';
import { CadastroLembreteComponent } from './cadastro-lembrete/cadastro-lembrete.component';
import { LembreteService } from './lembrete.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { DatePipe } from '@angular/common';
import { ListaLembreteComponent } from './lista-lembrete/lista-lembrete.component';
import { TableModule } from 'primeng/table';

@NgModule({
  declarations: [
    AppComponent,
    CadastroLembreteComponent,
    ListaLembreteComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ButtonModule,
    CalendarModule,
    HttpClientModule,
    ReactiveFormsModule,
    TableModule,
  ],
  providers: [LembreteService, HttpClient, DatePipe, ListaLembreteComponent],
  bootstrap: [AppComponent],
})
export class AppModule {}
