import { Component, OnInit } from '@angular/core';
import { Evaluation } from '../evaluation';
import { EvaluationService } from '../evaluation.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-list-evaluation',
  templateUrl: './list-evaluation.component.html',
  styleUrls: ['./list-evaluation.component.css']
})
export class ListEvaluationComponent implements OnInit{
  constructor(private evaluationService: EvaluationService,
    private route: ActivatedRoute,
    private router: Router) { }
  
  courseid: string;
  star: number;
  formFilter: FormGroup;

  public evaluations: Evaluation[];
  public imageURL: string;
  errorMessage: string;

  ngOnInit() {
    this.courseid = this.route.snapshot.params['courseId'];
    this.star = 0;
    this.evaluationService.getEvaluation(this.courseid,this.star)
      .subscribe(
        evaluations => this.evaluations = evaluations,
        error => this.errorMessage = error,
    );   

    this.formFilter = new FormGroup({
      stars : new FormControl('')
    });
  }

  deleteEvaluation(id:string){
    this.evaluationService.delete(id).subscribe(res => {
         this.evaluations = this.evaluations.filter(item => item.id !== id);
         console.log('Post deleted successfully!');
    })
  }

  seachEvaluation(){
    this.courseid = this.route.snapshot.params['courseId'];
    this.star = this.formFilter.controls.stars.value;
    this.evaluationService.getEvaluation(this.courseid,this.star)
      .subscribe(
        evaluations => this.evaluations = evaluations,
        error => this.errorMessage = error,
    );   
  }
}
