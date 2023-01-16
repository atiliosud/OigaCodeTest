import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Course } from 'src/app/course/course';
import { CourseService } from 'src/app/course/courses.service';
import { Evaluation } from '../evaluation';
import { EvaluationService } from '../evaluation.service';
import { Student } from '../students';
import { StudentService } from '../students.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
  
  id: string;
  evaluation: Evaluation;
  evaluationForm: FormGroup;
  students: Student[];
  courses: Course[];
  errors: any[] = [];

  constructor(
    private fb: FormBuilder,
    public evaluationService: EvaluationService,
    public studentService: StudentService,
    public courseService: CourseService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    
    this.courseService.getCourse()
      .subscribe(
        courses => this.courses = courses,
        fail => this.errors = fail.error.errors
      );

    this.studentService.getStudents()
      .subscribe(
        students => this.students = students,
        fail => this.errors = fail.error.errors
      );

  }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];

    this.evaluationService.get(this.id).subscribe((data: Evaluation)=>{
      this.evaluation = data;
    });

    

    this.evaluationForm = new FormGroup({
      id: new FormControl(''),
      courseId: new FormControl(''),
      studentId: new FormControl(''),
      description: new FormControl(''),
      stars: new FormControl('')
    });

    

    // this.evaluationForm.patchValue(this.evaluation);
    // // this.evaluationForm.controls.courseId.setValue(this.evaluation.courseId);
    // // this.evaluationForm.controls.studentId.setValue(this.evaluation.studentId);
    // this.evaluationForm.controls.description.setValue(this.evaluation.description);
    // this.evaluationForm.controls.stars.setValue(this.evaluation.stars);

  }

  get f(){
    return this.evaluationForm.controls;
  }

  submit(){
    console.log(this.evaluationForm.value);
    this.evaluationForm.controls.id.setValue(this.evaluation.id)
    this.evaluationService.update(this.id, this.evaluationForm.value).subscribe((res:any) => {
         console.log('Evaluation update successfully!');
         this.router.navigateByUrl('course');
    })
  }

  changeCourse(event: any){
    this.studentService.getStudentsCourse(event.target.value)
      .subscribe(
        students => this.students = students,
        fail => this.errors = fail.error.errors
      );

  }

}
