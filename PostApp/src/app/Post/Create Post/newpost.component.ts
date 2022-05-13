import { Component, Input, OnInit } from "@angular/core";
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Guid } from "guid-typescript";
import { Post } from "src/app/Models/post.model";
import { PostService } from "src/app/Services/Post/post.services";
import { DateService } from "src/app/Services/Shared/date.service";

@Component({
    selector: 'newpost-component',
    templateUrl: './newpost.component.html',
    styleUrls: ['./newpost.component.css']
  })
  export class NewPostComponent implements OnInit
  {
      @Input() user: any;
      postForm!: FormGroup;
      constructor(private postService: PostService, private dateService: DateService) {}
    ngOnInit(): void {
        this.postForm = new FormGroup({
            title: new FormControl('',[Validators.required, Validators.minLength(1), Validators.maxLength(50)]),
            content: new FormControl('',[Validators.required, Validators.minLength(20), Validators.maxLength(1000)])
        });

    }
    onSubmit(){
        let title = this.postForm.controls["title"].value
        let content = this.postForm.controls["content"].value
        let post = new Post();


        post.title = title
        post.id = Guid.create().toString();
        post.authorId = Guid.parse(this.user.id).toString();
        post.content = content;
        post.status = null;
        post.creationDate = this.dateService.generateDate();

        this.postService.create(post).subscribe(result => {
            console.log(result);
        })
    }
  }