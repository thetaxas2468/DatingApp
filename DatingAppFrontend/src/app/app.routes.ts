import { Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { MemberListComponent } from './pages/member-list/member-list.component';
import { MemberDetailComponent } from './pages/member-detail/member-detail.component';
import { ListsComponent } from './pages/lists/lists.component';
import { MessagesComponent } from './pages/messages/messages.component';
import { authGuard } from './guards/auth.guard';
export const routes: Routes = [
    {path: '', component: HomeComponent},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [authGuard],
        children: [
            {path: 'members', component: MemberListComponent},
            {path: 'members/:id', component: MemberDetailComponent},
            {path: 'lists', component: ListsComponent},
            {path: 'messages', component: MessagesComponent},
        ]
    },
    {path: '**', component: HomeComponent, pathMatch: 'full'},
];