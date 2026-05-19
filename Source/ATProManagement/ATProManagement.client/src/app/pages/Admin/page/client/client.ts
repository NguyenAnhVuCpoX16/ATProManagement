import { Component, OnInit, ViewChild } from '@angular/core';
import {
  GridModule,
  PageService,
  SortService,
  FilterService,
  ToolbarService,
  EditService,
  ExcelExportService,
  PdfExportService,
  GridComponent,
  RowRenderingDirection 
} from '@syncfusion/ej2-angular-grids';
import { Browser, enableRipple } from '@syncfusion/ej2-base';
import { Toolbar } from '../../../component/toolbar/toolbar';
import { CommonModule } from '@angular/common';

enableRipple(false);
@Component({
  selector: 'app-client',
  standalone: true,
  templateUrl: './client.html',
  styleUrl: './client.css',
  imports: [GridModule, Toolbar, CommonModule],
  providers: [
    PageService,
    SortService,
    FilterService,
    ToolbarService,
    EditService,
    ExcelExportService,
    PdfExportService,
  ],
})
export class Client implements OnInit {
  @ViewChild('grid')
  public grid!: GridComponent;
  public filterSettings: Object = { type: 'Excel' };
  public toolbarGrid: string[] = [
    'Add',
    'Edit',
    'Delete',
    'Update',
    'Cancel',
    'ExcelExport',
    'PdfExport',
  ];
  public editSettings: Object = {
    allowEditing: true,
    allowAdding: true,
    allowDeleting: true,
    mode: 'Dialog',
  };
  public orderidrules: Object = { required: true, number: true };
  public customeridrules: Object = { required: true };
  public freightrules: Object = { required: true, number: true };
  public initialPage: Object = { pageSize: 25, pageCount: 5 };
  public isDeskTop: Boolean = false;
  public rowMode: 'Horizontal' | 'Vertical' = 'Horizontal';

  dataGrid: any[] = [];
  ngOnInit(): void {
     this.isDeskTop = !Browser.isDevice;
     console.log('Is Desktop:', this.isDeskTop);
    for (let i = 1; i <= 100; i++) {
      this.dataGrid.push({
        guid: this.generateGuid(),
        timeCreated: new Date(),
        timeModify: new Date(),
        userCreated: `User${i % 5}`,
        userModified: `User${(i + 1) % 5}`,
        name: `Item ${i}`,
        description: `Description ${i}`,
      });
    }
  }

  onActionBegin(args: any): void {
    // 🔥 DELETE
    // ❌ chặn Syncfusion event trước
    if (args.requestType === 'delete') {
      args.cancel = this.isDeskTop;
      console.log('Delete row:', args.data);
    }

    // 🔥 SAVE EDIT
    if (args.requestType === 'save') {
      args.cancel = this.isDeskTop;
      console.log('Save row:', args.data);
    }

    // 🔥 ADD NEW
    if (args.requestType === 'add') {
      args.cancel = this.isDeskTop;
      console.log('Add row:', args.data);
    }
  }

  onActionComplete(args: any): void {
    if (args.requestType === 'save') {
      console.log('Saved successfully UI updated');
    }

    if (args.requestType === 'delete') {
      console.log('Deleted successfully UI updated');
    }
  }

  generateGuid() {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, (c) => {
      const r = (Math.random() * 16) | 0;
      const v = c === 'x' ? r : (r & 0x3) | 0x8;
      return v.toString(16);
    });
  }

  toolbarClick(args: any): void {
    console.log('Toolbar clicked:', args.item.id);
    const id = args.item.id || '';
    if (id.endsWith('excelexport')) {
      this.grid.excelExport();
    }

    if (id.endsWith('pdfexport')) {
      this.grid.pdfExport();
    }
  }
}
