import AccessControlService from '@/api-services/access-control'
export default function guest ({from, next, router}) {
  AccessControlService.CheckIsGuest(from, next, router)
}
