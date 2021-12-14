# 全部人工指定
[PortalAuthorize(action: "bbs:list.posts",forAccountToken:ValidationMode.Basic, forUserToken:ValidationMode.Fully)]

# 只驗 account / user token 的 baisc mode
[PortalAuthorize] 
`相當於`
[PortalAuthorize(action: "",forAccountToken:ValidationMode.Basic, forUserToken:ValidationMode.Basic)]

# 指定只驗 account / user token 的指定模式
[PortalAuthorize(forAccountToken:ValidationMode.Basic, forUserToken:ValidationMode.Fully)]
`相當於`
[PortalAuthorize(action: "",forAccountToken:ValidationMode.Basic, forUserToken:ValidationMode.Fully)]

# 只驗 action
[PortalAuthorize(action: "bbs:list.posts")]
`相當於`
[PortalAuthorize(action: "bbs:list.posts",forAccountToken:ValidationMode.Basic, forUserToken:ValidationMode.Basic)]




