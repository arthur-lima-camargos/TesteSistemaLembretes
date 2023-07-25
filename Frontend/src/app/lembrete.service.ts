import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Lembrete {
  id: null;
  name: string;
  date: string;
}
@Injectable({
  providedIn: 'root',
})
export class LembreteService {
  constructor(private http: HttpClient) {}

  createLembrete(lembrete: Lembrete): Observable<any> {
    return this.http.post(`http://localhost:8080/api/lembretes`, lembrete);
  }
  getLembrete(): Observable<any> {
    return this.http.get('http://localhost:8080/api/lembretes');
  }
  deleteLembreteById(id: any): Observable<any> {
    return this.http.delete(`http://localhost:8080/api/lembretes/` + id);
  }
}
