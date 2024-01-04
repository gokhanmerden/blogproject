import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { KredilerDto } from '../models/krediler.dto';

@Injectable({
  providedIn: 'root'
})
export class KredilerService {

  constructor(private httpClient: HttpClient) { }

  getKrediler() {
    return this.httpClient.get<KredilerDto[]>(environment.serverUrl + "/krediler")
  }
}
