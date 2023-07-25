import { Component, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Lembrete, LembreteService } from '../lembrete.service';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-cadastro-lembrete',
  templateUrl: './cadastro-lembrete.component.html',
  styleUrls: ['./cadastro-lembrete.component.scss'],
})
export class CadastroLembreteComponent {
  cadastroForm: FormGroup;
  minDate: any;
  constructor(
    private fb: FormBuilder,
    private lembreteService: LembreteService,
    private datePipe: DatePipe
  ) {
    this.cadastroForm = this.fb.group({
      id: [''],
      name: ['', Validators.required],
      date: ['', Validators.required],
    });
  }

  ngOnInit(): void {
    this.minDate = new Date();
  }

  @Output() newItemEvent = new EventEmitter<string>();

  applyCadastro() {
    const dateValue = this.cadastroForm.controls['date'].value;
    const nameValue = this.cadastroForm.controls['name'].value;
    const formattedDate = this.datePipe.transform(dateValue, 'dd/MM/yyyy');

    var lembrete: Lembrete = {
      id: null,
      name: nameValue,
      date: formattedDate as string,
    };
    this.lembreteService.createLembrete(lembrete).subscribe(
      (response) => {
        this.cadastroForm.controls['date'].reset();
        this.cadastroForm.get('name')?.reset();
        this.newItemEvent.emit('update');
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
