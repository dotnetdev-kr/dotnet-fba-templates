#!/usr/bin/env dotnet
#:ref Sample.cs OutputItemType=Analyzer ReferenceOutputAssembly=false
using Sample;

Hello.World();

[Friend] class Github;
[Friend] class DotnetDev;

/*
dotnet Sample.Test.cs

소스제너레이터를 로컬 파일 그대로 분석기로 참조합니다. 패키징이 필요 없습니다.
#:ref 뒤에 붙은 OutputItemType=Analyzer 가 핵심이고, 이 아이템 메타데이터 문법은
.NET 11 RC2 부터 동작합니다. (#:project 는 프로젝트 파일만 받으므로 .cs 에는 쓸 수 없습니다)
*/