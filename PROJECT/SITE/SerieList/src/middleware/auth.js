import AccessControlService from '@/api-services/access-control'
export default function auth ({next}) {
  AccessControlService.CheckIsAuth(next)
}
