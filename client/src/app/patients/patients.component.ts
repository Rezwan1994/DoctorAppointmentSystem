import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { jqxDataTableComponent } from 'jqwidgets-ng/jqxdatatable';

@Component({
  selector: 'app-patients',
  templateUrl: './patients.component.html',
  styleUrls: ['./patients.component.scss']
})
export class PatientsComponent implements OnInit {
  @ViewChild('myDataTable') myDataTable: jqxDataTableComponent;

  constructor(private http: HttpClient) { }
	getWidth() : any {
		if (document.body.offsetWidth < 850) {
			return '100%';
		}
		
		return 1000;
	}
	
    columns: any[] =
    [
        { text: 'Token', dataField: 'Token', width: 200 },
        { text: 'Name', dataField: 'Name', width: 200 },
        { text: 'Phone', dataField: 'Phone', width: 250 },
        { text: 'Address', dataField: 'Address', width: 100, align: 'right', cellsAlign: 'right', cellsFormat: 'c2' },
        { text: 'City', dataField: 'City', width: 100, align: 'right', cellsAlign: 'right', cellsFormat: 'n' },
        { Text: 'Action', dataField: 'Action', width: 150, align: 'right', cellsAlign: 'right',
        cellsrenderer: function () {
          return "<a href='#' class='btn btn-default btn-xs'>" + "<i class='fa fa-folder'></i>View</a>" +
          "<button class= 'btn btn-danger btn-xs js-delete'><i class='fa fa-trash-o'></i>Delete</button>"
        } }
    ];

  ngOnInit(): void {
 
   

  }
 



}
