import { NgModule } from '@angular/core';
import {MatButtonModule,
   MatButtonToggleModule, 
   MatIconModule, 
   MatToolbarModule,
   MatSidenavModule,
   MatMenuModule } from '@angular/material';


const Material = [
  MatButtonModule,
  MatButtonToggleModule,
  MatIconModule,
  MatToolbarModule,
  MatSidenavModule,
  MatMenuModule
]

@NgModule({
  imports: [Material],
  exports: [Material]
})
export class MaterialModule { }
