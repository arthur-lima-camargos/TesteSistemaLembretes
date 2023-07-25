import { Component } from '@angular/core';
import { LembreteService } from './lembrete.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  listaLembretes: any;
  constructor(private lembreteService: LembreteService) {}

  ngOnInit() {
    this.getAllLembretes();
  }
  addItem(value: string) {
    this.getAllLembretes();
  }
  getAllLembretes() {
    this.lembreteService.getLembrete().subscribe(
      (data) => {
        if (data == null) {
          this.listaLembretes = [];
          return;
        }
        this.listaLembretes = Object.entries(data).map(([date, lembrete]) => ({
          date,
          lembrete,
        }));
      },
      (error) => {
        console.error(error);
      }
    );
  }
}
