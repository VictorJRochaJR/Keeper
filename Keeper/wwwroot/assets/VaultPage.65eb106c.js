import{x as a,c as e,p as t,h as s,z as l,A as d,d as c,o as i,a as u,b as v,k as n,i as o,t as r,F as p,j as V,w as h}from"./vendor.37d5b467.js";import{v as m,A as w}from"./index.4ad0d75e.js";const g={setup(){const t=l();return d(),a((async()=>{await m.getKeepsByVaultId(t.params.id)})),{activeVault:e((()=>w.activeProfileVault)),vaultKeeps:e((()=>w.vaultKeeps)),account:e((()=>w.account)),async deleteVault(){await m.deleteVault(this.activeVault.id)}}}},z=h();t("data-v-644c1a3d");const f={class:"col-2"},k=v("path",{d:"M5.5 5.5A.5.5 0 0 1 6 6v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm2.5 0a.5.5 0 0 1 .5.5v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm3 .5a.5.5 0 0 0-1 0v6a.5.5 0 0 0 1 0V6z"},null,-1),y=v("path",{"fill-rule":"evenodd",d:"M14.5 3a1 1 0 0 1-1 1H13v9a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V4h-.5a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1H6a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1h3.5a1 1 0 0 1 1 1v1zM4.118 4 4 4.059V13a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1V4.059L11.882 4H4.118zM2.5 3V2h11v1h-11z"},null,-1),K={class:"card-columns"};s();const x=z(((a,e,t,s,l,d)=>{const h=c("ActiveVaultKeepTemplate");return i(),u("div",null,[v("div",f,[s.account.id==s.activeVault.creatorId?(i(),u("svg",{key:0,onClick:e[1]||(e[1]=(...a)=>s.deleteVault&&s.deleteVault(...a)),xmlns:"http://www.w3.org/2000/svg",width:"40",height:"40",fill:"gray",class:"bi bi-trash",viewBox:"0 0 16 16"},[k,y])):n("",!0)]),o(" "+r(s.vaultKeeps.length)+" ",1),v("div",K,[(i(!0),u(p,null,V(s.vaultKeeps,(a=>(i(),u(h,{key:a.id,keep:a},null,8,["keep"])))),128))])])}));g.render=x,g.__scopeId="data-v-644c1a3d";export default g;