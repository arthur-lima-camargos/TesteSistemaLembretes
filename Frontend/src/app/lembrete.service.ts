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
    return this.http.post(`https://localhost:7106/api/lembretes`, lembrete);
  }
  getLembrete(): Observable<any> {
    return this.http.get('https://localhost:7106/api/lembretes');
  }
  deleteLembreteById(id: any): Observable<any> {
    return this.http.delete(`https://localhost:7106/api/lembretes/` + id);
  }
}
