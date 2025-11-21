import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class SignService 
{
    http = inject(HttpClient)
    register(model:any)
    {
    return this.http.post(`${environment.api}/Users `, model)
    }
}
