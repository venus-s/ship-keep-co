import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { environment } from '../../environments/environment';

@Injectable()
export abstract class BaseApiService {

  private apiUrl = environment.API_URL + '/ShipKeepCo/Voyage';
  
  constructor(protected http: HttpClient) { }
}