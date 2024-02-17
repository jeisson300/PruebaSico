import { Component } from '@angular/core';
import { EventStudent, Student } from './interface/student.interface';
import { GeneralServices } from './services/general.service';
import { environment } from './environments/environment';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'PruebaSicoAngular_Frontend';

  public filter: string = '';
  public Students: Student[] = [];
  constructor(private generalService: GeneralServices) {
    this.Students = generalService.Students;
    this.loadStudents();
  }

  public async loadStudents() {
    const url: string = `${environment.baseUrl}/GetAllStudents`;
    const data = await this.generalService.sendPetionPost(url, {
      filter: this.filter.trim(),
    });
    this.Students = data;
  }
}
