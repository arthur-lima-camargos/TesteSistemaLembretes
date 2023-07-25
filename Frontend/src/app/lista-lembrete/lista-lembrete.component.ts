import { Component, Input, OnChanges } from '@angular/core';
import { LembreteService } from '../lembrete.service';

@Component({
  selector: 'app-lista-lembrete',
  templateUrl: './lista-lembrete.component.html',
  styleUrls: ['./lista-lembrete.component.scss'],
})
export class ListaLembreteComponent {
  constructor(private lembreteService: LembreteService) {}

  @Input() listaLembretes: any = [];
  ngOnChanges() {}

  deleteLembrete(id: number) {
    this.lembreteService.deleteLembreteById(id).subscribe((value) => {
      this.getAllLembretes();
    });
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
        console.log(this.listaLembretes);
      },
      (error) => {
        console.error(error);
      }
    );
  }
}
