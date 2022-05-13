import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Post } from 'src/app/Models/post.model';
import { PostService } from 'src/app/Services/Post/post.services';

@Component({
    selector: 'editpost-component',
    templateUrl: './editpost.component.html',
    //   styleUrls: ['./editpost.component.css']
})
export class EditPostComponent {
    user: any;
    postForm!: FormGroup;
    @Input() post!: Post;
    @Output() cancel = new EventEmitter<boolean>();


    constructor(private postService: PostService) {
    }


    ngOnInit() {
        this.postForm = new FormGroup({
            title: new FormControl('', [Validators.required, Validators.minLength(1), Validators.maxLength(50)]),
            content: new FormControl('', [Validators.required, Validators.minLength(20), Validators.maxLength(1000)])
        });
        this.loadPost()
    }

    loadPost(){
        this.postForm.controls["title"].setValue(this.post.title)
        this.postForm.controls["content"].setValue(this.post.content)
    }

    onSubmit() {
        let title = this.postForm.controls["title"].value
        let content = this.postForm.controls["content"].value
        let post = new Post();

        post.id = this.post.id
        post.title = title
        post.content = content

        this.postService.update(post).subscribe(result => {
            console.log(result)
            alert("")
            this.cancel.emit(true)
        })
    }

    back() {
        this.cancel.emit(true);
    }
}