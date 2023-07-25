import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListaLembreteComponent } from './lista-lembrete.component';

describe('ListaLembreteComponent', () => {
  let component: ListaLembreteComponent;
  let fixture: ComponentFixture<ListaLembreteComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ListaLembreteComponent]
    });
    fixture = TestBed.createComponent(ListaLembreteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
