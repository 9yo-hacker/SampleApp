import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable, inject, signal } from "@angular/core";
import { ReplaySubject, map } from "rxjs";
import { environment } from "../environments/environment";
import User from "../models/user.entity";
import { Router } from "@angular/router";


@Injectable({
  providedIn: 'root'
})
export class AuthService {

  http = inject(HttpClient)
  currentUser$ = new ReplaySubject<User>(1);
  currentUser = signal<User | null>(null)
  token: string = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoidXNlciIsImV4cCI6MTc2ODkzNzgyNX0.H5ELw1tzIEX_RdwZrLmEbkaDiLCukEtQWykp55U3-I0"
  public router = inject(Router)

  login(model: any){
    
    return this.http.post<User>(`${environment.api}/Users/Login`, model, this.generateHeaders()).pipe(
      map((response: User) => {
        const user = response;
        if(user){
          localStorage.setItem("user",JSON.stringify(user))
          this.currentUser$.next(user)
          console.log(user)
        }
        else{
          console.log(response)
        }
      })
    )
  }
  logout() {
    localStorage.removeItem('user');
    this.currentUser.set(null);
    this.router.navigate(['auth']);
  }

  private generateHeaders = () => {
    return {
      headers: new HttpHeaders({'Content-Type': 'application/json','Authorization': 'Bearer ' + this.token})
    }
  }

}

