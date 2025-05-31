import { Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { MemberListComponent } from './pages/member-list/member-list.component';
import { MemberDetailComponent } from './pages/member-detail/member-detail.component';
import { ListsComponent } from './pages/lists/lists.component';
import { MessagesComponent } from './pages/messages/messages.component';
import { authGuard } from './guards/auth.guard';
import { NotFoundComponent } from './pages/not-found/not-found.component';
import { ServerErrorComponent } from './pages/server-error/server-error.component';
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
    {path: 'not-found', component: NotFoundComponent, pathMatch: 'full'},
    {path: 'server-error', component: ServerErrorComponent, pathMatch: 'full'},
    {path: '**', component: HomeComponent, pathMatch: 'full'},
];