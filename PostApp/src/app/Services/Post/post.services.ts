import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Post } from "src/app/Models/post.model";
import { DateService } from "../Shared/date.service";

@Injectable({ providedIn: 'root', })
export class PostService {
    private _url = "https://localhost:7286/api/";
    private _endpoint = "post";

    constructor(private http: HttpClient, private dateService: DateService) {
    }

    create(post: Post): Observable<any> {
        return this.http.post<any>(`${this._url}${this._endpoint}/Create`,post);
    }
    getposts(){
        return this.http.get<any>(`${this._url}${this._endpoint}/GetPosts`)
    }
    getpending(userId: string){
        return this.http.get<any>(`${this._url}${this._endpoint}/GetPending/${userId}`)
    }
    getByUser(userId: string){
        return this.http.get<any>(`${this._url}${this._endpoint}/GetByUser/${userId}`)
    }
    update(post: Post){
        return this.http.put<any>(`${this._url}${this._endpoint}/Update`,{
            id: post.id,
            title: post.title,
            content: post.content
        })
    }
    review(id: string, status: string){
        let approvalDate = this.dateService.generateDate()
        return this.http.put<any>(`${this._url}${this._endpoint}/Review`,{
            id: id,
            status:status,
            approvalDate: approvalDate
        })
    }
    delete(id:string){
        return this.http.delete<any>(`${this._url}${this._endpoint}/Delete?post=${id}`)
    }

}