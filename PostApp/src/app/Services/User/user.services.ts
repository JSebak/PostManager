import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { v4 as uuidv4 } from 'uuid';

@Injectable({ providedIn: 'root', })
export class UserService {
    private _url = "https://localhost:7286/api/";
    private _endpoint = "user";

    constructor(private http: HttpClient) {
    }

    login(username: string, password: string): Observable<any> {
        return this.http.post<any>(`${this._url}${this._endpoint}/Login`,{
            username: username,
            password: password
        });
    }
    register(username: string, password: string, role: any){
        return this.http.post<any>(`${this._url}${this._endpoint}/Register`,{
            id: uuidv4(),
            username,
            password,
            role
        })
    }

}